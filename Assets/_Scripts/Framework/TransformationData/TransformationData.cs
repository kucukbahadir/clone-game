using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationData", menuName = "Scriptable Objects/TransformationData")]
[Serializable]
public class TransformationData : ScriptableObject
{
    [SerializeField] private TransformationType transformType;
    [SerializeField] private GameObject transformMesh;

    public TransformationType GetTransformType() => transformType;
    public GameObject GetTransformMesh() => transformMesh;
}
