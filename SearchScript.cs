using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public SearchList[] SQuestions;
    public Text[] SAnswersText;
    public Text QSText;
    public GameObject RSPanel;
    public Text rsText;
    public GameObject SRestartButton;
    public Text GameScore;

    List<object> SList;

    SearchList curQuestion;

    int randQS;
    int points;
    int WrongPoints;

    public void StartSearch()
    {
        points = 0;
        SList = new List<object>(SQuestions);
        GenerateQuestions();
    }

    public void GenerateQuestions()
    {
        GameScore.text = ($"{points} / 10");
        if (points < 10)
        {
            randQS = Random.Range(0, SList.Count);
            curQuestion = SList[randQS] as SearchList;
            QSText.text = curQuestion.question;
            for (int i = 0; i < curQuestion.answers.Length; i++)
                SAnswersText[i].text = curQuestion.answers[i];
        }

        else
        {
            rsText.text = ($"Ваш результат - {points} / {WrongPoints}!");
            RSPanel.SetActive(true);
            SRestartButton.SetActive(true);
        }

    }

    public void SAnswerButtons(int index)
    {
        if (SAnswersText[index].text.ToString() == curQuestion.answers[randQS])
        {
            points += 1;
            GenerateQuestions();
        }
        else
        {
            WrongPoints += 1;
            GenerateQuestions();
        }
    }
}

[System.Serializable]
public class SearchList
{
    public string question;
    public string[] answers = new string[10];
}
