using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private InteractUI interactableUI;

    protected bool _isInteractable = true;

    public abstract void OnInteract(object sender);

    public void InRange()
    {
        interactableUI.Show();
    }

    public void OutOfRange()
    {
        interactableUI.Hide();
    }

    public bool GetIsInteractable => _isInteractable;

    public static EventHandler OnCorrectInteraction;
}
