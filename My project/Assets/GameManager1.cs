using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

     public GameObject Panel;

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

        if (unansweredQuestions.Count > 0) {
        GetCurrentQuestion();
    } else {
        Debug.Log("No more questions left!");
        Panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; 
        
    }



    }


    public void UserSelectTrue(){

        if(currentQuestion.isTrue){
            Debug.Log("Correct");
        }else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

    public void UserSelectFalse(){

        if(currentQuestion.isTrue){
            Debug.Log("Wrong");
        }else
        {
            Debug.Log("Correct");
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    



}
