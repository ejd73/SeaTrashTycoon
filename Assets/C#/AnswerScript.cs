using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QA qa;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            qa.correct();

        } else 
        {
            Debug.Log("InCorrect");
            qa.correct();
        }
    }
}
