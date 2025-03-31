using System;
using UnityEngine;

public class TransformAction : BaseAction
{
    public static EventHandler<Action<TransformationData>> OnTransformationAction;
    public EventHandler<TransformationEventArg> OnNewTransformation;
    
    [SerializeField] private GameObject defaultCloneGraphics;

    private GameObject _currentTransformation;
    private Animator defaultAnimator;

    private void Start()
    {
        defaultAnimator = _animator;
    }

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
            OnNewTransformation?.Invoke(this, new TransformationEventArg(null, defaultAnimator));
            _OnActionComplete?.Invoke();
            return;
        }

        defaultCloneGraphics.SetActive(false);
        Destroy(_currentTransformation);
        _currentTransformation = Instantiate(transformationData.GetTransformationMesh, transform.position, transform.rotation);
        _currentTransformation.transform.SetParent(transform);
        var transformationAnimator = _currentTransformation.GetComponent<Animator>();
        OnNewTransformation?.Invoke(this, new TransformationEventArg(transformationData.GetTransformationName, transformationAnimator));

        _OnActionComplete?.Invoke();
    }
}
