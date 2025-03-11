using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformationUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject transformationUISlot;

    protected void Awake()
    {
        Panel.SetActive(false);
    }

    public void OpenTransformUI()
    {

    }
}
