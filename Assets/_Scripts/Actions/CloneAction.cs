using System;
using UnityEngine;

public class CloneAction : BaseAction
{
    [SerializeField] private GameObject unitClonePrefab;
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        
        var pos = UnityEngine.Random.insideUnitSphere * 5;
        Instantiate(unitClonePrefab, new Vector3(pos.x,0,pos.z), Quaternion.identity);

        _OnActionComplete?.Invoke();
    }
}
