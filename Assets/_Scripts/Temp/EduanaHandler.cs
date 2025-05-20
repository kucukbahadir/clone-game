using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

public class EduanaHandler : MonoBehaviour
{
    private string apiBase = "http://localhost:8080/";

    public void GetInfo()
    {
        //StartCoroutine(FetchKeywords(apiBase));
        StartCoroutine(SendKeywords(apiBase));
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

    private IEnumerator SendKeywords(string apiBasePath)
    {
        var newKeywords = new keywords();
        var json = JsonUtility.ToJson(newKeywords);
        print(newKeywords.keywordName);
        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        var request = new UnityWebRequest(apiBasePath, "PUT");


        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to send progress.");
        }
    }
}

public class keywords
{
    public string keywordName = "jsonBorn";
}
