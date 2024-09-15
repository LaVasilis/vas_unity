using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager1 : MonoBehaviour
{

     public GameObject Panel;
     public GameObject gameOverText;
     public GameObject CorrectText;
     public GameObject FalseText;
     public GameObject FText;
    public static bool isInConversation = false;
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start()
    {
        if (unansweredQuestions== null || unansweredQuestions.Count == 0 ){
            unansweredQuestions=questions.ToList<Question>();
        }

        GetCurrentQuestion();
        Debug.Log(currentQuestion.fact + "is" + currentQuestion.isTrue);

    }

    void GetCurrentQuestion(){
        int randomQuestionIndex = Random.Range(0,unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        
        factText.text= currentQuestion.fact;

        

    }

    IEnumerator TransitionToNextQuestion(){

        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds (timeBetweenQuestions);
        FText.SetActive(false);
        CorrectText.SetActive(false);

        if (unansweredQuestions.Count > 0) {
        GetCurrentQuestion();
    } else {
        Debug.Log("No more questions left!");
        Panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; 
        gameOverText.SetActive(true);
        yield return new WaitForSeconds (4);
        gameOverText.SetActive(false);
    }



    }
    


    public void UserSelectTrue(){

        if(currentQuestion.isTrue){
            Debug.Log("Correct");
            CorrectText.SetActive(true);
            
        }else
        {
            Debug.Log("Wrong");
            FText.SetActive(true);
            
            
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse(){

        if(currentQuestion.isTrue){
            Debug.Log("Wrong");
            FText.SetActive(true);
        }else
        {
            Debug.Log("Correct");
            CorrectText.SetActive(true);
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    



}
