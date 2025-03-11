using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private TransformationUISlot transformationUISlot;

    protected void Awake()
    {
        Panel.SetActive(false);
    }

    public void OpenTransformUI(List<string> transformationNames)
    {
        foreach (var name in transformationNames)
        {
            var newTransformationUISlot = Instantiate(transformationUISlot);
            newTransformationUISlot.GetSlotText().text = name;
            newTransformationUISlot.transform.SetParent(Panel.transform);
        }
        
        Panel.SetActive(true);
    }
}
