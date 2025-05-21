using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using System.Collections.Generic;

public class EduanaHandler : MonoBehaviour
{
    private string apiBase = "http://localhost:8080/";

    public void GetInfo()
    {
        //StartCoroutine(FetchKeywords(apiBase));
        //StartCoroutine(SendKeywords(apiBase));
    }

    private IEnumerator FetchKeywords(string apiBasePath)
    {
        var request = UnityWebRequest.Get(apiBasePath);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            var json = request.downloadHandler.text;
            print(json);
        }
        else
        {
            print("error");
        }

    }

    // private IEnumerator SendKeywords(string apiBasePath)
    // {
    //     //var newKeywords = new keywords();
    //     var json = JsonUtility.ToJson(newKeywords);
    //     print(newKeywords.keywordName);
    //     var bytes = System.Text.Encoding.UTF8.GetBytes(json);
    //     var request = new UnityWebRequest(apiBasePath, "PUT");


    //     request.uploadHandler = new UploadHandlerRaw(bytes);
    //     request.downloadHandler = new DownloadHandlerBuffer();
    //     request.SetRequestHeader("Content-Type", "application/json");

    //     yield return request.SendWebRequest();

    //     if (request.result != UnityWebRequest.Result.Success)
    //     {
    //         Debug.LogError("Failed to send progress.");
    //     }
    // }
}

// public class keywords
// {
//     public string keywordName = "jsonBorn";
// }


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
