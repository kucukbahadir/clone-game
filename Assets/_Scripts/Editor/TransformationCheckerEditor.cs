using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(TransformationChecker))]
public class TransformationCheckerEditor : Editor
{
    private TransformationChecker _transformationChecker;
    private string _transformationDataHolderPath = "Assets/Prefabs/ScriptableObjects/TransformationDataHolder/TransformationDataHolder.asset";
    private List<string> _transformationNames = new List<string>();

    private int transformationIndex = 0;

    private void OnEnable()
    {
        _transformationChecker = (TransformationChecker)target;
        var transformationDataHolder = AssetDatabase.LoadAssetAtPath<TransformationDataHolder>(_transformationDataHolderPath);
        
        foreach (var transformation in transformationDataHolder.GetTransformations())
        {
            if (_transformationNames.Contains(transformation.name)) continue;
            _transformationNames.Add(transformation.name);
        }

        transformationIndex = GetIndexByTransformationName(_transformationChecker.GetRequiredTransformation);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();   

        EditorGUI.BeginChangeCheck();
        transformationIndex = EditorGUILayout.Popup("Required transformation",transformationIndex, _transformationNames.ToArray());
        if(EditorGUI.EndChangeCheck())
        {
            _transformationChecker.SetRequiredTransformation(GetTransformationNameByIndex(transformationIndex));
        }
    }

    private string GetTransformationNameByIndex(int index)
    {
        for (int i = 0; i < _transformationNames.Count; i++)
        {
            if(i != index) continue;
            return _transformationNames[i];
        }

        return null;
    }

    private int GetIndexByTransformationName(string name)
    {
        for (int i = 0; i < _transformationNames.Count; i++)
        {
            if(_transformationNames[i] != name) continue;
            return i;
        }

        return 0;
    }
}
