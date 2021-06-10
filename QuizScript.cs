using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScript : MonoBehaviour
{
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject RPanel;
    public Text rText;
    public GameObject RestartButton;

    List<object> qList;
    QuestionList curQuestion;
    int randQ;
    int points;

    public void StartQuiz()
    {
        points = 0;
        qList = new List<object>(questions);
        GenerateQuestions();
    }

    public void GenerateQuestions()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            curQuestion = qList[randQ] as QuestionList;
            qText.text = curQuestion.question;
            List<string> answers = new List<string>(curQuestion.answers);
            for (int i = 0; i < curQuestion.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            rText.text = ("Вы победили в викторине!");
            RPanel.SetActive(true);
            RestartButton.SetActive(true);
        }

    }

     public void AnswerButtons(int index)
     {
        if (answersText[index].text.ToString() == curQuestion.answers[0])
        {
            points += 100;
            qList.RemoveAt(randQ);
            GenerateQuestions();
        }
        else
        {
            rText.text = ($"Игра окончена! Ваш результат {points} очков");
            RPanel.SetActive(true);
            RestartButton.SetActive(true);
        }
     }
}

[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}