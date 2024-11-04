using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QA : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ChoiceA;
    public GameObject ChoiceB;
    public GameObject ChoiceC;
    public GameObject ChoiceD;
    public int choice;

    public void choseA () {
        TextBox.GetComponent<Text>().text = "You have chosen A.";
        choice = 1;
    }

    public void choseB () {
        TextBox.GetComponent<Text>().text = "You have chosen B.";
        choice = 2;
    }

    public void choseC () {
        TextBox.GetComponent<Text>().text = "You have chosen C.";
        choice = 3;
    }

    public void choseD () {
        TextBox.GetComponent<Text>().text = "You have chosen D.";
        choice = 4;
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (choice >= 1) {
            ChoiceA.SetActive(false);
            ChoiceB.SetActive(false);
            ChoiceC.SetActive(false);
            ChoiceD.SetActive(false);

        }
    }
}
