using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

public class EduanaHandler : MonoBehaviour
{
    [SerializeField] private List<string> keywords = new List<string>();
    private string apiBase = "http://localhost:8080/";

    public void HandleFetchKeywords()
    {
        StartCoroutine(FetchKeywords(apiBase));
    }

    public void HandleSendingData()
    {
        StartCoroutine(SendKeywords(apiBase));
    }

    [ExecuteAlways]
    private IEnumerator FetchKeywords(string apiBasePath)
    {
        var request = UnityWebRequest.Get(apiBasePath);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var requestText = request.downloadHandler.text.Split(',', '"', '[', ']', ' ')
                                    .Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();


            keywords.Clear();

            foreach (var keyword in requestText)
            {
                keywords.Add(keyword);
            }

            print("Request handled successfully");
        }
        else
        {
            Debug.LogError("Failed to get keywords. Request result: " + request.result);
        }

    }

    private IEnumerator SendKeywords(string apiBasePath)
    {
        var keywordsClass = new keywords();
        keywordsClass.myKeywords = keywords.ToArray();
        var json = JsonUtility.ToJson(keywordsClass);
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(apiBasePath, "PUT");


        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to send progress. Request result: " + request.result);
        }
    }
}

public class keywords
{
    public string[] myKeywords;
}


//Method die aangroepen word als we keywords van de back-end willen hebben
public class GetKeywords
{
    public Keyword[] keywords;
}

//The keyword class en de informatie
public class Keyword
{
    public int id;
    public string name;
    public Question[] questions;

    public Keyword(int id, string name, Question[] questions)
    {
        this.id = id;
        this.name = name;
        this.questions = questions;
    }
}

public class Question
{
    public string text;
    public Dictionary<string, Answer> answers;
    public string correct_answer_id;
}

public class Answer
{
    public string text;
}
