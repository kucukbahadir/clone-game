using System;
using TMPro;
using UnityEngine;

public class QuestionGiver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI answer1Text;
    [SerializeField] private TextMeshProUGUI answer2Text;
    [SerializeField] private TextMeshProUGUI answer3Text;

    void Start()
    {
        EduanaManager.Instance.GetNextQuestion(GetNextQuestionCallBack);
    }

    private void GetNextQuestionCallBack(Question question)
    {
        var answerIndex = 1;
        questionText.text = question.text;

        answer1Text.text = question.answers[answerIndex.ToString()].text;
        answerIndex++;
        answer2Text.text = question.answers[answerIndex.ToString()].text;
        answerIndex++;
        answer3Text.text = question.answers[answerIndex.ToString()].text;
    }
}
