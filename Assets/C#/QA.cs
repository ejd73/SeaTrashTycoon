using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QA : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text qText;

    
    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void setAnswers()
    {
        for (int i = 0;  i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i]; 

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }        
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);
        qText.text = QnA[currentQuestion].Question;
        setAnswers();
    }
}

