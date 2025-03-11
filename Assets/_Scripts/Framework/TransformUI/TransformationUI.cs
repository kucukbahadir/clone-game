using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject holder;
    [SerializeField] private TransformationUISlot transformationUISlot;

    public EventHandler<string> OnNewTransformationSelected;

    private void Awake()
    {
        holder.SetActive(false);
    }

    private void Start()
    {
        TransformationUISlot.OnTransformationSelected += OnTransformationSelected;
    }  

    public void SetUpTransformUI(List<string> transformationNames)
    {
        foreach (var name in transformationNames)
        {
            var newTransformationUISlot = Instantiate(transformationUISlot);
            newTransformationUISlot.UpdateSlotText(name);
            newTransformationUISlot.transform.SetParent(panel.transform);
        }
    }

    public void OpenTransformUI()
    {
        holder.SetActive(true);
    }

    private void OnTransformationSelected(object sender ,string transformationName)
    {
        OnNewTransformationSelected?.Invoke(this,transformationName);
        CloseTransformUI();
    }

    public void OnDefaultTransformationSelected()
    {
        OnNewTransformationSelected?.Invoke(this,null);
        CloseTransformUI();
    }

    private void CloseTransformUI()
    {
        holder.SetActive(false);
    }
}
