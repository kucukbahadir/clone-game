using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChecker : MonoBehaviour
{
    private List<Interactable> _currentInteractablesInRange = new List<Interactable>();

    private Interactable _closestInteractable;

    private bool _updateChecker = true;

    private void Start()
    {
        InputHandler.Instance.OnSwitchUnitInput += OnSwitchUnit;
        UnitClone.OnUnitCloneSpawn += DisableAllInteractableUI;
    }

    private void OnSwitchUnit(object sender, EventArgs e)
    {
        var currentUnit = UnitManager.Instance.GetCurrentUnit;
        var thisUnit = GetComponentInParent<BaseUnit>().GetUnitReference;
        DisableAllInteractableUI(sender, e);

        if(currentUnit == thisUnit)
        {
            _updateChecker = true;
            _closestInteractable?.OnInRange();
        }
    }

    private void DisableAllInteractableUI(object sender, EventArgs e)
    {
        _updateChecker = false;
        foreach (var interactable in _currentInteractablesInRange)
        {
            interactable.OnOutOfRange();
        }
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
        if(!_updateChecker) return;
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
