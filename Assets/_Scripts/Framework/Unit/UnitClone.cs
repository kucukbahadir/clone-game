using System;
using UnityEditor.UI;
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
        TransformAction.OnNewTransformation += OnNewTransformation;
    }

    private void OnNewTransformation(object sender, string newTransformationName)
    {
        currentTransformation = newTransformationName != null ? newTransformationName : "Default";
    }

    public string GetCurrentTransformation => currentTransformation;

    void OnDisable() => TransformAction.OnNewTransformation -= OnNewTransformation;
}
