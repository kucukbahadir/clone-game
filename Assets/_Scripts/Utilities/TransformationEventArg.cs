using System;
using UnityEngine;

public class TransformationEventArg : EventArgs
{
    public string transformationName;
    public Animator transformationAnimator;

    public TransformationEventArg(string transformationName, Animator transformationAnimator)
    {
        this.transformationName = transformationName;
        this.transformationAnimator = transformationAnimator;
    }
}
