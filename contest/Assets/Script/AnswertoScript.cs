using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswertoScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuastionMnager quastionMnager;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quastionMnager.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quastionMnager.correct();
        }
    }
}
