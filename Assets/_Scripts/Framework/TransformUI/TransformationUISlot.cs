using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slotText;
    [SerializeField] private Button button;

    public static EventHandler<string> OnTransformationSelected;

    private void OnEnable()
    {
        button.onClick.AddListener(SelectedTransformation);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(SelectedTransformation);
    }

    public void UpdateSlotText(string newText)
    {
        slotText.text = newText;
    }

    private void SelectedTransformation()
    {
        OnTransformationSelected?.Invoke(this,slotText.text);
    }
}
