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
        print("Transform");
        yield return new WaitForSeconds(2f);
        _OnActionComplete?.Invoke();
    }
}
