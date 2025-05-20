using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

public class EduanaHandler : MonoBehaviour
{
    [SerializeField] private string keywordName;
    private string apiBase = "http://localhost:8080/";
    private string apiBaseKeywords = "http://localhost:8080/keywords";

    public void GetInfo()
    {
        StartCoroutine(FetchKeywords(apiBase));
        StartCoroutine(FetchKeywords(apiBaseKeywords));       
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
}
