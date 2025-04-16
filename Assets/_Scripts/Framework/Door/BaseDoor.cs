using System;
using UnityEngine;
using System.Collections.Generic;

public class BaseDoor : MonoBehaviour
{
    [SerializeField] private List<Interactable> requiredInteractables = new List<Interactable>();

    private Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
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

    protected virtual void OpenDoor()
    {
        _animator.SetTrigger("OpenDoor");
    }

    private void OnDisable()
    {
        TransformationChecker.OnRightTransformationInteraction -= OnRightTransformationInteraction;       
    }
}
