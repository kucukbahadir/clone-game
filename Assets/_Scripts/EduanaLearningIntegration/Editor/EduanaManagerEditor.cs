using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EduanaManager))]
public class EduanaManagerEditor : Editor
{
    private EduanaManager _eduanaManager;
    private Color _normalBackgroundColor;
    private Color _LabelBoxColor = Color.blue;

    private SerializedProperty _minimumKeywordAmountBeforeFetching;
    private SerializedProperty _apiURLContainer;
    private SerializedProperty _useLocalJSON;
    private SerializedProperty _localJSONFile;
    private SerializedProperty _keywords;

    void OnEnable()
    {
        _eduanaManager = (EduanaManager)target;
        _normalBackgroundColor = GUI.backgroundColor;

        _minimumKeywordAmountBeforeFetching = serializedObject.FindProperty("minimumKeywordAmountBeforeFetching");
        _apiURLContainer = serializedObject.FindProperty("apiURLContainer");
        _useLocalJSON = serializedObject.FindProperty("useLocalJSON");
        _localJSONFile = serializedObject.FindProperty("localJSONFile");
        _keywords = serializedObject.FindProperty("keywords");
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Fetch keywords", GUILayout.Height(30)))
        {
            _eduanaManager.TotalReset();
            _eduanaManager.StartCoroutine(_eduanaManager.FetchKeywords());
        }

        if (GUILayout.Button("Reset", GUILayout.Height(30)))
        {
            _eduanaManager.TotalReset();
        }

        GUI.backgroundColor = _LabelBoxColor;

        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Dit is een rode balk met tekst", EditorStyles.boldLabel);
        EditorGUILayout.EndVertical();

        GUI.backgroundColor = _normalBackgroundColor;

        serializedObject.Update();

        EditorGUILayout.PropertyField(_minimumKeywordAmountBeforeFetching);
        EditorGUILayout.PropertyField(_apiURLContainer);
        EditorGUILayout.PropertyField(_useLocalJSON);
        EditorGUILayout.PropertyField(_localJSONFile);
        EditorGUILayout.PropertyField(_keywords);

        serializedObject.ApplyModifiedProperties();
    }
}
