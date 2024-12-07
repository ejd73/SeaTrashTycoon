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
    private List<QuestionsAnswers> originalQnA; // Backup for the original question list

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

    // public void reset()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
    public void reset()
    {
        // Reset score and UI
        score = 0;
        GOPanel.SetActive(false); // Hide the game over panel
        QuizPanel.SetActive(true); // Show the quiz panel

        // Restore the original question list
        QnA = new List<QuestionsAnswers>(originalQnA);

        // Start from the first question
        generateQuestion();
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);
        sText.text = "Congratulations quiz crusher! Your accuracy is: " + score + "/" + totalQ;
    
        // Pass quiz points to the CoinManager to update the coins 
        CoinManager.instance.AwardQuizCoins(score, totalQ);    
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

