using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

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

        unansweredQuestions.RemoveAt(randomQuestionIndex);

    }


    public void UserSelectTrue(){

        if(currentQuestion.isTrue){
            Debug.Log("Correct");
        }else
        {
            Debug.Log("Wrong");
        }
    }

    public void UserSelectFalse(){

        if(currentQuestion.isTrue){
            Debug.Log("Wrong");
        }else
        {
            Debug.Log("Correct");
        }
    }



}
