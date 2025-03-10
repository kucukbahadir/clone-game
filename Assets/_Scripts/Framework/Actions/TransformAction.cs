using System;
using UnityEngine;
using System.Collections;

public class TransformAction : BaseAction
{
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        StartCoroutine(TransformTime());
    }

    IEnumerator TransformTime()
    {
        TransformUI.Instance.OpenTransformUI();
        yield return new WaitForSeconds(2f);
        _OnActionComplete?.Invoke();
    }
}
