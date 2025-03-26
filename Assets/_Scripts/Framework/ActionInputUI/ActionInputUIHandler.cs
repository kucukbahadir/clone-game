using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionInputUIHandler : MonoBehaviour
{
    [SerializeField] private List<ActionInputUI> actionInputUIs = new List<ActionInputUI>();

    private void Start()
    {
        UnitManager.Instance.OnSwitchToNewUnit += OnSwitchToNewUnit;

        OnSwitchToNewUnit(null,null);
    }

    private void OnSwitchToNewUnit(object sender, EventArgs e)
    {
        DisableAllActionUI();

        var currentUnit = UnitManager.Instance.GetCurrentUnit;

        var allCurrentUnitActions = currentUnit.GetAllActions;

        foreach (var action in allCurrentUnitActions)
        {
            foreach (var ActionInputUI in actionInputUIs)
            {
                if(action.GetActionType() != ActionInputUI.GetActionType) continue;

                ActionInputUI.gameObject.SetActive(true);
            }
        }
    }

    private void DisableAllActionUI()
    {
        foreach (var ActionInputUI in actionInputUIs)
        {
            ActionInputUI.gameObject.SetActive(false);
        }
    }
}
