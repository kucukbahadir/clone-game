using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationDataHolder", menuName = "Scriptable Objects/TransformationDataHolder")]
public class TransformationDataHolder : ScriptableObject
{
    [SerializeField] private List<TransformationData> transformations = new List<TransformationData>();

    public TransformationData GetTransformationData(TransformationType transformationType)
    {
        var transformationData = transformations[0];

        foreach (var Data in transformations)
        {
            if (Data.GetTransformType() != transformationType) continue;
            transformationData = Data;
            break;
        }

        return transformationData;
    }
    
}
