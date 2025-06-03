using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EduanaManager))]
public class EduanaManagerEditor : Editor
{
    private EduanaManager _eduanaManager;
    private Color _normalBackgroundColor;
    private Color _LabelBoxColor = Color.blue;

    void OnEnable()
    {
        _eduanaManager = (EduanaManager)target;
        _normalBackgroundColor = GUI.backgroundColor;
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

        // Begin een gekleurde box
        EditorGUILayout.BeginVertical("box");
        GUILayout.Label("Dit is een rode balk met tekst", EditorStyles.boldLabel);
        EditorGUILayout.EndVertical();

        // Achtergrondkleur herstellen
        GUI.backgroundColor = _normalBackgroundColor;

        base.OnInspectorGUI();
    }
}
