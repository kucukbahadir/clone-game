using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationDataHolder", menuName = "Scriptable Objects/TransformationDataHolder")]
public class TransformationDataHolder : ScriptableObject
{
    [SerializeField] private List<TransformationData> transformations = new List<TransformationData>();    
}
