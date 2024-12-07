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
    //public GameObject rightSign;
    //public GameObject wrongSign;

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
        sText.text = "Congratulations quiz crusher! Your accuracy is: " + score + "/" + totalQ;

    // Calculate points for the quiz
    // ADD float quizPoints = score * 0.05f; // Each question is worth 0.05 points
        float quizPoints = 0.5f; // Base points for scoring at least 1 correct answer
        if (score == totalQ) 
        {
            quizPoints = 0.5f; // Max 0.5 points for perfect score (already the base)
        }
    
        // Pass quiz points to the GameManager to update the score bar
        GameManager.instance.AddQuizPoints(quizPoints);
    }

    // void GameOver()
    // {
    //     QuizPanel.SetActive(false);
    //     GOPanel.SetActive(true);
    //     sText.text = "Congratulations quiz crusher! You accuracy is: " + score + "/" +totalQ;
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correct()
    {
        score += 1;
        //rightSign.SetActive(true);
        //yield return new WaitForSeconds(2);
        //rightSign.SetActive(false);
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
       // wrongSign.SetActive(true);
        //yield return new WaitForSeconds(2);
        //wrongSign.SetActive(false);
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

