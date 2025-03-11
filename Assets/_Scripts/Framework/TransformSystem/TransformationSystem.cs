using UnityEngine;

public class TransformationSystem : MonoBehaviourSingleton<TransformationSystem>
{
    [SerializeField] private TransformationDataHolder transformationDataHolder;
    protected override void Awake()
    {
        base.Awake();
    }
}
