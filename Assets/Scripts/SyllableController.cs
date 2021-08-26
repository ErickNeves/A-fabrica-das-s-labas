using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 
====================================
Script responsavel por fazer todo o controle e tratamento dos sacos de farinha
Também é o responsavel por sua movimentação.
====================================

*/

public class SyllableController : MonoBehaviour
{

    #region Declarations

    [SerializeField]
    private string mySyllable;

    [SerializeField]
    private GameControler gameControler;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private Transform myTransform;

    [SerializeField]
    private Vector2 rightForce = new Vector2(60, 0);
    private Vector3 initialPosition;

    [SerializeField]
    private Sprite mySpriteHover; //Imagem Hover do Obj, definido pelo Inspector
    private Sprite mySprite; //Imagem Padrão do Obj, pego ao iniciar.

    #endregion



    #region UnityBasics

    private void Awake()
    {
        //Pega a pos inicial do eixo X, define um ponto de respawn padrão em Y e armazena.
        initialPosition = new Vector3(-7.56f, gameObject.GetComponent<Transform>().position.y, 0f);
    }


    void Start()
    {

        myBody = gameObject.GetComponent<Rigidbody2D>();
        myTransform = gameObject.GetComponent<Transform>();
        mySprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        //GoRight();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    public string TakeSyllable()
    {
        return mySyllable;
    }

    #region Movimentacao

    public void GoRight()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
        myBody.AddForce(rightForce);
    }

    public void StopMoviment()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        myBody.velocity = new Vector3(0,0,0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            myTransform.SetPositionAndRotation(initialPosition, new Quaternion(0, 0, 0, 0));
        }
    }

    #endregion


    #region InteracaoMouse

    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mySpriteHover;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = mySprite;
    }

    private void OnMouseUpAsButton()
    {
        gameControler.CheckAnswer(gameObject);
    }

    #endregion

}
