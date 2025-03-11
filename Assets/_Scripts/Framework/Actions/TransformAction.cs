using System;
using UnityEngine;

public class TransformAction : BaseAction
{
    public static EventHandler<Action<TransformationData>> OnTransformationAction;
    
    [SerializeField] private GameObject defaultCloneGraphics;

    private GameObject _currentTransformation;

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        OnTransformationAction?.Invoke(this, HandleNewTransformation);
    }

    private void HandleNewTransformation(TransformationData transformationData)
    {
        if(transformationData == null || transformationData.GetTransformationMesh == null)
        {
            Destroy(_currentTransformation);
            defaultCloneGraphics.SetActive(true);
            _OnActionComplete?.Invoke();
            return;
        }

        defaultCloneGraphics.SetActive(false);
        Destroy(_currentTransformation);
        _currentTransformation = Instantiate(transformationData.GetTransformationMesh);
        _currentTransformation.transform.SetParent(transform);
        _currentTransformation.transform.position = transform.position;

        _OnActionComplete?.Invoke();
    }
}
