using System;
using System.Collections.Generic;
using UnityEngine;

public class TransformationSystem : MonoBehaviourSingleton<TransformationSystem>
{
    [SerializeField] private TransformationDataHolder transformationDataHolder;
    [SerializeField] private TransformationUI transformationUI;

    private Action<TransformationData> _callBackAction;
    private List<string> transformationNames;

    protected override void Awake()
    {
        base.Awake();
        transformationNames = new List<string>();

        foreach (var transformation in transformationDataHolder.GetTransformations())
        {
            transformationNames.Add(transformation.GetTransformName());
        }
    }

    private void Start()
    {
        TransformAction.OnTransformationAction += OnTransformationActionUsed;
        transformationUI.OnNewTransformationSelected += OnNewTransformationSelected;
    }

    private void OnTransformationActionUsed(object sender,Action<TransformationData> callBackAction)
    {
        _callBackAction = callBackAction;

        transformationUI.OpenTransformUI(transformationNames);
    }

    private void OnNewTransformationSelected(object sender, string transformationName)
    {
        foreach (var transformationData in transformationDataHolder.GetTransformations())
        {
            if (transformationData.GetTransformName() != transformationName) continue;
            
            _callBackAction?.Invoke(transformationData);
        }
    }
}
