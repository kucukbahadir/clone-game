using UnityEngine;

[CreateAssetMenu(fileName = "ApiURLContainer", menuName = "Scriptable Objects/ApiURLContainer")]
public class ApiURLContainer : ScriptableObject
{
    public string RequestKeywordsApiURL;
    public string SendKeywordProgressApiURL;
}
