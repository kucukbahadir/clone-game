using UnityEngine;

public class TransformationChecker : MonoBehaviour
{
    [SerializeField] private string requiredTransformation;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent<UnitClone>(out var unitClone)) return;

        var unitCloneTransformation = unitClone.GetCurrentTransformation;

        if(unitCloneTransformation == null || unitCloneTransformation != requiredTransformation) return;

        print("good transformation");
    }
}
