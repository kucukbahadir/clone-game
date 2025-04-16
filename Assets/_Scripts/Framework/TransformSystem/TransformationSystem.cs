using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformationSystem : MonoBehaviour
{
    [SerializeField] private TransformationDataHolder transformationDataHolder;
    [SerializeField] private TransformationUI transformationUI;

    public UnityEvent OnTransformationActionActive;

    private Action<TransformationData> _callBackAction;
    private List<string> transformationNames;

    protected void Awake()
    {
        transformationNames = new List<string>();

        foreach (var transformation in transformationDataHolder.GetTransformations())
        {
            transformationNames.Add(transformation.GetTransformationName);
        }
    }

    private void Start()
    {
        TransformAction.OnTransformationAction += OnTransformationActionUsed;
        transformationUI.OnNewTransformationSelected += OnNewTransformationSelected;

        transformationUI.SetUpTransformUI(transformationNames);
    }

    private void OnTransformationActionUsed(object sender,Action<TransformationData> callBackAction)
    {
        _callBackAction = callBackAction;
        OnTransformationActionActive?.Invoke();
    }

    private void OnNewTransformationSelected(object sender, string transformationName)
    {
        if (transformationName == null)
        {
            _callBackAction?.Invoke(null);
            return;
        }

        foreach (var transformationData in transformationDataHolder.GetTransformations())
        {
            if (transformationData.GetTransformationName != transformationName) continue;
            
            _callBackAction?.Invoke(transformationData);
        }
    }

    private void OnDisable()
    {
        TransformAction.OnTransformationAction -= OnTransformationActionUsed;
        transformationUI.OnNewTransformationSelected -= OnNewTransformationSelected;
    }
}
