using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TransformationData", menuName = "Scriptable Objects/TransformationData")]
[Serializable]
public class TransformationData : ScriptableObject
{
    [SerializeField] private string transformationName;
    [SerializeField] private GameObject transformationMesh;

    public GameObject GetTransformationMesh => transformationMesh;
    public string GetTransformationName => transformationName;
}
