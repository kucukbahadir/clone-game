using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private InteractUI interactableUI;

    public abstract void OnInteract<T>(T interactArg);

    public void OnInRange()
    {
        interactableUI.Show();
    }

    public void OnOutOfRange()
    {
        interactableUI.Hide();
    }
}
