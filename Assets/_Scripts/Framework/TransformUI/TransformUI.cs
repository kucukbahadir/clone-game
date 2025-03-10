using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransformUI : MonoBehaviourSingleton<TransformUI>
{
    [SerializeField] private TransformationDataHolder transformationDataHolder;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject transformUISlot;

    protected override void Awake()
    {
        base.Awake();
        Panel.SetActive(false);
    }

    public void OpenTransformUI()
    {
        foreach (var item in transformationDataHolder.GetTransformations())
        {
            var newTransformationSlot = Instantiate(transformUISlot);
            newTransformationSlot.transform.parent = Panel.transform;
            newTransformationSlot.GetComponent<TransformUISlot>().GetSlotText().text = item.name;
        }
        Panel.SetActive(true);
    }
}
