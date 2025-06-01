using UnityEngine;

[CreateAssetMenu(fileName = "ApiURLContainer", menuName = "Scriptable Objects/ApiURLContainer")]
public class ApiURLContainer : ScriptableObject
{
    public string RequestApiURL;
    public string SendKeywordProgressApiURL;
}
