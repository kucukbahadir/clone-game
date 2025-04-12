using System;
using System.Collections;
using UnityEngine;

public class CloneAction : BaseAction
{
    [SerializeField] private GameObject unitClonePrefab;
    [SerializeField] private int maxCLoneAmount = 5;

    private int _cloneUnitAmount = 0;
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;

        if(_cloneUnitAmount == maxCLoneAmount)
        {
            _OnActionComplete?.Invoke();
            return;
        }

        var pos = UnityEngine.Random.insideUnitSphere * 5;
        Instantiate(unitClonePrefab, new Vector3(pos.x,0,pos.z), Quaternion.identity);
        _cloneUnitAmount++;
        _OnActionComplete?.Invoke();
    }
}
