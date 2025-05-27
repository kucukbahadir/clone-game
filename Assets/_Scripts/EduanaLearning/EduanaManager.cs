using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class EduanaManager : MonoBehaviour
{
    public static EduanaManager Instance;

    [SerializeField] private TextAsset testJsonFile;
    [SerializeField] private List<Keyword> keywords = new List<Keyword>();

    [SerializeField] private Keyword _currentKeyword;
    [SerializeField] private int _currentKeywordIndex;
    [SerializeField] private int _currentQuestionIndex;

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

    public void GetNextQuestion(Action<Question> callbackAction)
    {
        var nextQuestion = _currentKeyword.questions[_currentQuestionIndex];
        _currentQuestionIndex++;
        callbackAction(nextQuestion);
    }

    private KeywordsContainer DeconstructJson(string JsonString)
    {
        return JsonConvert.DeserializeObject<KeywordsContainer>(JsonString);
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
        _currentKeywordIndex = 0;
        _currentQuestionIndex = 0;
    }

    public void TotalReset()
    {
        _currentKeyword = null;
        _currentKeywordIndex = 0;
        _currentQuestionIndex = 0;     

        keywords.Clear();
    }
}
