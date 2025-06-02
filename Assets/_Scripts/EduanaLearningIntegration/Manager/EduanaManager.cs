using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;
using System.Collections;

public class EduanaManager : MonoBehaviour
{
    public static EduanaManager Instance;

    [SerializeField] private int minimumKeywordAmountBeforeFetching = 2;
    [SerializeField] private ApiURLContainer apiURLContainer;
    [SerializeField] private bool useLocalJSON;
    [SerializeField] private TextAsset localJSONFile;
    [SerializeField] private List<Keyword> keywords = new List<Keyword>();
    [SerializeField] private bool autoFetch = true;
    [SerializeField] private bool showKeywordList;

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

        StartCoroutine(FetchKeywords());
        SetUpCurrentKeywordInfo();
    }

    [ExecuteAlways]
    public IEnumerator FetchKeywords()
    {
        if (useLocalJSON)
        {
            var keywordsContainer = DeconstructJson(localJSONFile.text);

            SetKeywordsInKeywordList(keywordsContainer);
        }
        else
        {
            var request = UnityWebRequest.Get(apiURLContainer.RequestKeywordsApiURL);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                print("Request handled successfully");
            }
            else
            {
                Debug.LogError("Failed to get keywords. Request result: " + request.result);
            }
        }

    }

    public IEnumerator SendKeywords(bool answerResult)
    {
        var keywordsClass = new KeywordProgress(_currentKeyword.id, answerResult, DateTime.Now.ToString());

        var json = JsonUtility.ToJson(keywordsClass);
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(apiURLContainer.SendKeywordProgressApiURL, "PUT");


        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to send progress. Request result: " + request.result);
        }
    }

    private KeywordsContainer DeconstructJson(string JsonString)
    {
        return JsonConvert.DeserializeObject<KeywordsContainer>(JsonString);
    }

    public Question GetNextKeywordQuestion()
    {
        if (_currentQuestionIndex >= _currentKeyword.questions.Length)
        {
            var nextKeyword = GetNextKeyword();
            _currentKeyword = nextKeyword;
            _currentQuestionIndex = 0;
        }

        if (_currentKeyword == null)
        {
            Debug.LogError("There are no keywords in the keywords list anymore, so there is no question left");
            return null;
        }

        var nextQuestion = _currentKeyword.questions[_currentQuestionIndex];
        _currentQuestionIndex++;
        return nextQuestion;
    }

    private Keyword GetNextKeyword()
    {
        keywords.Remove(_currentKeyword);

        if (autoFetch && keywords.Count <= minimumKeywordAmountBeforeFetching)
        {
            StartCoroutine(FetchKeywords());
        }

        return keywords.Count <= 0 ? null : keywords[0];
    }

    private void SetKeywordsInKeywordList(KeywordsContainer keywordsContainer)
    {
        foreach (var keyword in keywordsContainer.keywords)
        {
            if (CheckIfKeywordIsInList(keyword)) continue;
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

    private bool CheckIfKeywordIsInList(Keyword target)
    {
        var isInList = false;

        foreach (var keyword in keywords)
        {
            if (keyword.id == target.id) isInList = true;
        }

        return isInList;
    }
}
