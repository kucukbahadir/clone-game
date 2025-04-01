using System;
using UnityEngine;

public class UnitClone : BaseUnit
{
    [SerializeField,ReadOnly] private string currentTransformation;
    public static EventHandler OnUnitCloneSpawn;

    protected override void Awake()
    {
        base.Awake();
        OnUnitCloneSpawn?.Invoke(this, null);
        currentTransformation = "Default";     
    }

    private void Start()
    {
        foreach (var action in _unitActions)
        {
            if (action.GetActionType() != ActionTypes.Transform) continue;
            
            var transformAction = (TransformAction)action;
            transformAction.OnNewTransformation += OnNewTransformation;
        }
    }

    private void OnNewTransformation(object sender, TransformationEventArg transformationEventArg)
    {
        currentTransformation = transformationEventArg.transformationName != null ? transformationEventArg.transformationName : "Default";

        foreach (var action in _unitActions)
        {
            action.SetAnimator(transformationEventArg.transformationAnimator);
        }
    }

    public string GetCurrentTransformation => currentTransformation;
}
