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
    private SerializedProperty _autoFetch;
    private SerializedProperty _showKeywordList;

    void OnEnable()
    {
        _eduanaManager = (EduanaManager)target;
        _normalBackgroundColor = GUI.backgroundColor;

        _minimumKeywordAmountBeforeFetching = serializedObject.FindProperty("minimumKeywordAmountBeforeFetching");
        _apiURLContainer = serializedObject.FindProperty("apiURLContainer");
        _useLocalJSON = serializedObject.FindProperty("useLocalJSON");
        _localJSONFile = serializedObject.FindProperty("localJSONFile");
        _keywords = serializedObject.FindProperty("keywords");
        _autoFetch = serializedObject.FindProperty("autoFetch");
        _showKeywordList = serializedObject.FindProperty("showKeywordList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CreateLabelBox("Keyword fetch settings");

        EditorGUILayout.PropertyField(_useLocalJSON);
        if (_useLocalJSON.boolValue)
        {
            EditorGUILayout.PropertyField(_localJSONFile);
        }
        EditorGUILayout.PropertyField(_autoFetch);
        if (_autoFetch.boolValue)
        {     
            EditorGUILayout.PropertyField(_minimumKeywordAmountBeforeFetching);
        }

        CreateLabelBox("Api settings");
        EditorGUILayout.PropertyField(_apiURLContainer);

        CreateLabelBox("Debug settings");
        EditorGUILayout.PropertyField(_showKeywordList);
        if (_showKeywordList.boolValue)
        {
            EditorGUILayout.PropertyField(_keywords);    
        }
        
        if (GUILayout.Button("Fetch keywords", GUILayout.Height(30)))
        {
            _eduanaManager.TotalReset();
            _eduanaManager.StartCoroutine(_eduanaManager.FetchKeywords());
        }

        if (GUILayout.Button("Reset keyword list", GUILayout.Height(30)))
        {
            _eduanaManager.TotalReset();
        }


        serializedObject.ApplyModifiedProperties();
    }

    private void CreateLabelBox(string label)
    {
        GUI.backgroundColor = _LabelBoxColor;

        GUILayout.Space(5);

        EditorGUILayout.BeginVertical("box");
        GUILayout.Label(label, EditorStyles.boldLabel);
        EditorGUILayout.EndVertical();

        GUILayout.Space(5);

        GUI.backgroundColor = _normalBackgroundColor;       
    }
}
