using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChecker : MonoBehaviour
{
    private List<Interactable> _currentInteractablesInRange = new List<Interactable>();

    private Interactable _closestInteractable;

    private void Start()
    {
        InputHandler.Instance.OnSwitchUnitInput += DisableAllInteractableUI;
        UnitClone.OnUnitCloneSpawn += DisableAllInteractableUI;
    }

    private void DisableAllInteractableUI(object sender, EventArgs e)
    {
        foreach (var interactable in _currentInteractablesInRange)
        {
            interactable.OnOutOfRange();
        }

        _closestInteractable = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Interactable>(out var interactable)) return;

        _currentInteractablesInRange.Add(interactable);

        if(_currentInteractablesInRange.Count > 1) return;

        _closestInteractable = interactable;
        _closestInteractable.OnInRange();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Interactable>(out var interactable)) return;

        _currentInteractablesInRange.Remove(interactable);

        interactable.OnOutOfRange();
    }

    private void Update()
    {
        if(_closestInteractable == null) return;
        foreach (var interactable in _currentInteractablesInRange)
        {
            var newDistance = Vector3.Distance(transform.position, interactable.transform.position);

            if(newDistance >= Vector3.Distance(transform.position, _closestInteractable.transform.position)) continue;

            _closestInteractable.OnOutOfRange();
            _closestInteractable = interactable;
            _closestInteractable.OnInRange();
        }
    }

    public Interactable GetClosestInteractable => _closestInteractable;
}
