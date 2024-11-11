using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QA : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GOPanel;

    public Text qText;
    public Text sText;

    int totalQ = 0;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        totalQ = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        sText.text = score + "/" +totalQ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
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
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            qText.text = QnA[currentQuestion].Question;
            setAnswers();
        } else {
            Debug.Log("Out of questions");
            GameOver();
        }
    }
}

