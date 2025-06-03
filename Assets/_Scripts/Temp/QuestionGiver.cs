using System;
using TMPro;
using UnityEngine;

public class QuestionGiver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI answer1Text;
    [SerializeField] private TextMeshProUGUI answer2Text;
    [SerializeField] private TextMeshProUGUI answer3Text;

    private Question question;

    void Start()
    {
        question = EduanaManager.Instance.GetNextKeywordQuestion();
    }

    private void GetNextQuestionCallBack()
    {
        if (question == null) return;
        var answerIndex = 1;
        questionText.text = question.text;

        answer1Text.text = question.answers[answerIndex.ToString()].text;
        answerIndex++;
        answer2Text.text = question.answers[answerIndex.ToString()].text;
        answerIndex++;
        answer3Text.text = question.answers[answerIndex.ToString()].text;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            question = EduanaManager.Instance.GetNextKeywordQuestion();
        }

        GetNextQuestionCallBack();
    }
}
