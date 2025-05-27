using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class EduanaManager : MonoBehaviour
{
    public static EduanaManager Instance;

    [SerializeField] private int minimumKeywordAmountBeforeFetching = 2;

    [SerializeField] private TextAsset testJsonFile;
    [SerializeField] private List<Keyword> keywords = new List<Keyword>();

    private Keyword _currentKeyword;
    private int _currentQuestionIndex;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        FetchKeywords();
        SetUpCurrentKeywordInfo();
    }

    [ExecuteAlways]
    public void FetchKeywords()
    {
        //Hierin word er naar de front-end of back-end geroepen // dit moet uiteindelijk niet leeg gemaakt worden maar waarneer alle vragen gedaan zijn dat hij dan zichzelf verwijder

        var keywordsContainer = DeconstructJson(testJsonFile.text);

        SetKeywordsInKeywordList(keywordsContainer);
    }

    private KeywordsContainer DeconstructJson(string JsonString)
    {
        return JsonConvert.DeserializeObject<KeywordsContainer>(JsonString);
    }

    public void GetNextQuestion(Action<Question> callbackAction)
    {
        if (_currentQuestionIndex >= _currentKeyword.questions.Length)
        {
            var nextKeyword = GetNextKeyword();
            _currentKeyword = nextKeyword;
            _currentQuestionIndex = 0;
        }
        var nextQuestion = _currentKeyword.questions[_currentQuestionIndex];
        _currentQuestionIndex++;
        callbackAction(nextQuestion);
    }

    private Keyword GetNextKeyword()
    {
        keywords.Remove(_currentKeyword);
        CheckIfEnoughKeywords();

        return keywords[0];
    }

    private void CheckIfEnoughKeywords()
    {
        if (keywords.Count > minimumKeywordAmountBeforeFetching) return;
        FetchKeywords();
    }

    private void SetKeywordsInKeywordList(KeywordsContainer keywordsContainer)
    {
        foreach (var keyword in keywordsContainer.keywords)
        {
            keywords.Add(keyword);
        }
    }

    private void SetUpCurrentKeywordInfo()
    {
        if (_currentKeyword != null && keywords.Count <= 0) return;

        _currentKeyword = keywords[0];
        _currentQuestionIndex = 0;
    }

    public void TotalReset()
    {
        _currentKeyword = null;
        _currentQuestionIndex = 0;     

        keywords.Clear();
    }
}
