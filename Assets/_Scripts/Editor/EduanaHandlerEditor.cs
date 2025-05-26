using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EduanaHandler))]
public class EduanaHandlerEditor : Editor
{
    private EduanaHandler _eduanaHandler;

    void OnEnable()
    {
        _eduanaHandler = (EduanaHandler)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Fetch keywords", GUILayout.Height(30)))
        {
            _eduanaHandler.HandleFetchKeywords();
        }

        if (GUILayout.Button("Send keywords", GUILayout.Height(30)))
        {
            _eduanaHandler.HandleSendingData();
        }
    }
}
