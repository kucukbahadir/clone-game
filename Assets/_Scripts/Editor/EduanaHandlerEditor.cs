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
        if (GUILayout.Button("back end test"))
        {
            _eduanaHandler.GetInfo();
        }
    }
}
