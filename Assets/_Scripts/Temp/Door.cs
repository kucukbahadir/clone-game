using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Material doorOpenMaterial;
    [SerializeField] private GameObject doorMesh;
    [SerializeField] private SceneAsset NextScene;
    [SerializeField] private BoxCollider doorBoxCollider;

    [SerializeField] private List<Interactable> requiredInteractables = new List<Interactable>();

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = doorMesh.GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        TransformationChecker.OnRightTransformationInteraction += OnRightTransformationInteraction;
    }

    private void OnRightTransformationInteraction(object sender, EventArgs e)
    {
        var canOpenDoor = true;
        foreach (var Interactable in requiredInteractables)
        {
            if(!Interactable.GetIsInteractable) continue;
            canOpenDoor = false;
            break;
        }

        if(!canOpenDoor) return;
        OpenDoor();
    }

    private void OpenDoor()
    {
        _renderer.material = doorOpenMaterial;
        doorBoxCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<BaseUnit>(out var unit)) return;

        SceneManager.LoadScene(NextScene.name);
    }

    private void OnDisable()
    {
        TransformationChecker.OnRightTransformationInteraction -= OnRightTransformationInteraction;        
    }
}
