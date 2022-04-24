using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuastionMnager : MonoBehaviour
{
    public List<QuasitonAndAnswer> QA;
    public GameObject[] options;
    public int correntLQusetion;

    public Text questionText;

    private void Start()
    {
        GenerateQuestion();
    }

    public void correct()
    {

        QA.RemoveAt(correntLQusetion);
        GenerateQuestion();
    }

     void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswertoScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QA[correntLQusetion].Answer[i];

            if(QA[correntLQusetion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswertoScript>().isCorrect = true;
            }

        }
    }

    void GenerateQuestion()
    {
        correntLQusetion = Random.Range(0, QA.Count);

        questionText.text = QA[correntLQusetion].Question;
        SetAnswers();
    }
}
