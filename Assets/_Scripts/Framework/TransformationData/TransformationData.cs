using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationData", menuName = "Scriptable Objects/TransformationData")]
[Serializable]
public class TransformationData : ScriptableObject
{
    [SerializeField] private string transformName;
    [SerializeField] private GameObject transformMesh;
    [SerializeField] private TransformationType transformType;

    public TransformationType GetTransformType() => transformType;
    public GameObject GetTransformMesh() => transformMesh;
    public string GetTransformName() => transformName;
}
