using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private TransformationUISlot transformationUISlot;

    public EventHandler<string> OnNewTransformationSelected;

    private void Awake()
    {
        Panel.SetActive(false);
    }

    private void Start()
    {
        TransformationUISlot.OnTransformationSelected += OnTransformationSelected;
    }

    public void OpenTransformUI(List<string> transformationNames)
    {
        foreach (var name in transformationNames)
        {
            var newTransformationUISlot = Instantiate(transformationUISlot);
            newTransformationUISlot.UpdateSlotText(name);
            newTransformationUISlot.transform.SetParent(Panel.transform);
        }

        Panel.SetActive(true);
    }

    private void OnTransformationSelected(object sender ,string transformationName)
    {
        OnNewTransformationSelected?.Invoke(this,transformationName);
        CloseTransformUI();
    }

    private void CloseTransformUI()
    {
        Panel.SetActive(false);
    }
}
