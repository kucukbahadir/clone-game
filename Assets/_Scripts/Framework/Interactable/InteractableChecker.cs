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
        UnitManager.Instance.OnSwitchToNewUnit += OnSwitchUnit;
    }

    private void OnSwitchUnit(object sender, EventArgs e)
    {
        var currentUnit = UnitManager.Instance.GetCurrentUnit;
        var thisUnit = GetComponentInParent<BaseUnit>().GetUnitReference;
        DisableAllInteractableUI();

        if(currentUnit == thisUnit)
        {
            _updateChecker = true;
            
            if(_currentInteractablesInRange.Count <= 0) return;
            _closestInteractable = _currentInteractablesInRange[0];
            _closestInteractable.InRange();
        }
    }

    private void DisableAllInteractableUI()
    {
        _updateChecker = false;
        foreach (var interactable in _currentInteractablesInRange)
        {
            interactable.OutOfRange();
        }

        _closestInteractable = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Interactable>(out var interactable)) return;

        _currentInteractablesInRange.Add(interactable);

        if(_currentInteractablesInRange.Count > 1) return;

        _closestInteractable = interactable;
        _closestInteractable.InRange();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Interactable>(out var interactable)) return;

        _currentInteractablesInRange.Remove(interactable);

        interactable.OutOfRange();
    }

    private void Update()
    {
        if(!_updateChecker) return;
        foreach (var interactable in _currentInteractablesInRange)
        {
            var newDistance = Vector3.Distance(transform.position, interactable.transform.position);

            if(newDistance >= Vector3.Distance(transform.position, _closestInteractable.transform.position)) continue;

            _closestInteractable.OutOfRange();
            _closestInteractable = interactable;
            _closestInteractable.InRange();
        }
    }

    public Interactable GetClosestInteractable => _closestInteractable;
}
