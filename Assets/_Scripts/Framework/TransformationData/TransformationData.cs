using System;
using UnityEngine;

[Serializable]
public class TransformationData
{
    [SerializeField, ReadOnly] private int transformID;
    [SerializeField] private GameObject transformMesh;

    public void ChangeTransformID(int newTransformID)
    {
        transformID = newTransformID;
    }

    public int GetTransformID() => transformID;
    public GameObject GetTransformMesh => transformMesh;
}
