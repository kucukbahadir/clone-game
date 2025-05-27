using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EduanaManager))]
public class EduanaManagerEditor : Editor
{
    private EduanaManager _eduanaManager;

    void OnEnable()
    {
        _eduanaManager = (EduanaManager)target;
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Fetch keywords", GUILayout.Height(30)))
        {
            _eduanaManager.FetchKeywords();
        }

        if (GUILayout.Button("Reset", GUILayout.Height(30)))
        {
            _eduanaManager.TotalReset();
        }
        base.OnInspectorGUI();
    }
}
