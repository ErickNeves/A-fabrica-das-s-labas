using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = new GameObject[6];

    [SerializeField]
    private GameObject tutorial;

    public int QuantPlay = 0;

    [SerializeField]
    private GameObject finalScreen;

    [SerializeField]
    private Sprite[] syllableSprite = new Sprite[8];

    [SerializeField]
    private int syllableNumber = 1;

    [SerializeField]
    private int maxPlays = 5;

    [SerializeField]
    private Sprite wrongSyllable;

    [SerializeField]
    private string storedAnswer;

    [SerializeField]
    private string completeAnswer;

   

    [SerializeField]
    private string[] palavrasUsadas = new string[5];

    [SerializeField]
    private int nrPalavrasUsadas = 0;

    [SerializeField]
    private GameObject[] painelSyllable = new GameObject[2];

    [SerializeField]
    private GameObject painelRepetido;

    [SerializeField]
    private Animator domAnimator;

    [SerializeField]
    private GameObject forninho;

    private AudioController audioController;

    [SerializeField]
    private SyllableController[] syllableRef = new SyllableController[8];

    [SerializeField]
    private SpriteRenderer rosquinhaSprite;

    [SerializeField]
    private Sprite[] rosquinhasTipos = new Sprite[3];

    private void Awake()
    {
        //ShuffleQuestions();
        audioController = gameObject.GetComponent<AudioController>();
        
        
    }

    private void Start()
    {


    }

    public void CloseTutoAndStart() //FECHA TUTORIAL E INICIA GAME
    {
        tutorial.SetActive(false);
        StartTurn();
    }

    private void StartTurn() //INICIA TURNO
    {
        ControleSilabas(true);
    }

    IEnumerator WrongAnswer() //RESPOSTA INCORRETA
    {
        domAnimator.SetTrigger("Errou");
        QuantPlay++;
        yield return new WaitForSeconds(1.5f);

    }

    private void CorrectAnswer()
    {
        StartCoroutine("AtivarForninho");
        syllableNumber = 1;
        QuantPlay++;


    }

    public void CheckAnswer(GameObject clickedObj)
    {

        string newSyllable = clickedObj.GetComponent<SyllableController>().TakeSyllable();

        bool repetido = false;

        if (syllableNumber == 1)
        {

            if (newSyllable == "de")
            {
                clickedObj.GetComponent<SpriteRenderer>().sprite = wrongSyllable;
                StartCoroutine("WrongAnswer");
            }
            else
            {
                storedAnswer = newSyllable;
                AlterarPainel(newSyllable);
                syllableNumber++;
            }

        }
        else
        {
            completeAnswer = "";
            completeAnswer = storedAnswer + newSyllable;
            AlterarPainel(newSyllable);

            switch (completeAnswer)
            {
                case "bolo":

                    for(int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "bolo")
                        {
                            repetido = true;
                        }
                            
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(0);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "bode":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "bode")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(1);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "sapo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "sapo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(2);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "copo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "copo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(3);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "saco":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "saco")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(4);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "lobo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "lobo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(5);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "polo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "polo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(6);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "colo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "colo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(7);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "suco":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "suco")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(8);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                case "gelo":
                    for (int i = 0; i < palavrasUsadas.Length; i++)
                    {
                        if (palavrasUsadas[i] == "gelo")
                            repetido = true;
                    }

                    if (!repetido)
                    {
                        CorrectAnswer();
                        palavrasUsadas[nrPalavrasUsadas] = completeAnswer;
                        audioController.PlayAudio(9);
                        nrPalavrasUsadas++;
                    }
                    else
                    {
                        StartCoroutine("PalavraRepetida");
                    }
                    break;

                default:
                    StartCoroutine("WrongAnswer");
                    clickedObj.GetComponent<SpriteRenderer>().sprite = wrongSyllable;
                    painelSyllable[1].GetComponent<SpriteRenderer>().sprite = null;
                    
                    break;
            }

        }

    }

    private void AlterarPainel(string syllable)
    {

        switch (syllable)
        { //ge sa de bo co su po lo
            case "ge":
                painelSyllable[syllableNumber-1].GetComponent<SpriteRenderer>().sprite = syllableSprite[0];
                break;
            case "bo":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[1];
                break;
            case "lo":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[2];
                break;
            case "sa":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[3];
                break;
            case "co":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[4];
                break;
            case "su":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[5];
                break;
            case "po":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[6];
                break;
            case "de":
                painelSyllable[syllableNumber - 1].GetComponent<SpriteRenderer>().sprite = syllableSprite[7];
                break;
            case "clear":
                painelSyllable[0].GetComponent<SpriteRenderer>().sprite = null;
                painelSyllable[1].GetComponent<SpriteRenderer>().sprite = null;
                break;
            default:
                break;
        }

    }

    private void ControleSilabas(bool ativado)
    {
        foreach (var item in syllableRef)
        {
            if (ativado)
            {
                item.GoRight();
            }
            else
            {
                item.StopMoviment();
            }
        }
    }

    private void ShuffleQuestions()     //EMBARALHAR FRASES
    {
        for (int i = 0; i < questions.Length; i++)
        {
            GameObject obj = questions[i];
            int randomizeArray = Random.Range(0, i);
            questions[i] = questions[randomizeArray];
            questions[randomizeArray] = obj;
        }
    }

    IEnumerator PalavraRepetida()
    {
        painelRepetido.SetActive(true);
        ControleSilabas(false);
        AlterarPainel("clear");
        syllableNumber = 1;
        yield return new WaitForSeconds(2);
        painelRepetido.SetActive(false);
        ControleSilabas(true);
    }

    IEnumerator AtivarForninho()
    {
        ControleSilabas(false);
        rosquinhaSprite.sprite = rosquinhasTipos[Random.Range(0, 2)];
        forninho.SetActive(true);
        yield return new WaitForSeconds(4);
        AlterarPainel("clear");
        forninho.SetActive(false);
        if(nrPalavrasUsadas >= maxPlays)
        {
            finalScreen.SetActive(true);
        }
        else
        {
            ControleSilabas(true);
        }
        
    }

}
