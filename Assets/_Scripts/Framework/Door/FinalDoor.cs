using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : BaseDoor
{
    [SerializeField] private Material doorOpenMaterial;
    [SerializeField] private GameObject doorMesh;
    [SerializeField] private SceneAsset NextScene;
    [SerializeField] private BoxCollider doorBoxCollider;

    private MeshRenderer _renderer;

    protected override void Awake()
    {
        _renderer = doorMesh.GetComponent<MeshRenderer>();
    }

    protected override void OpenDoor()
    {
        _renderer.material = doorOpenMaterial;
        doorBoxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<BaseUnit>(out var unit)) return;

        SceneManager.LoadScene(NextScene.name);
    }
}
