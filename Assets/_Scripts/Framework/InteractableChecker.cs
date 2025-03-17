using UnityEngine;

public class InteractableChecker : MonoBehaviour
{
    [SerializeField]private IInteractable _currentInteractableInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IInteractable>(out var interactable)) return;

        print("Interaction in sight");
        _currentInteractableInRange = interactable;
    }

    public IInteractable GetCurrentInteractable => _currentInteractableInRange;
}
