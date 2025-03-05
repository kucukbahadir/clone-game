using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationDataHolder", menuName = "Scriptable Objects/TransformationDataHolder")]
public class TransformationDataHolder : ScriptableObject
{
    [SerializeField] private List<TransformationData> transformations = new List<TransformationData>();

    private int countOfTransformations;

    void OnValidate()
    {
        if (countOfTransformations == transformations.Count) return;
        countOfTransformations = transformations.Count;
        for (var i = 0; i < transformations.Count; i++)
        {
            var transformData = transformations[i];
            transformData.ChangeTransformID(i);
        }
    }
}
