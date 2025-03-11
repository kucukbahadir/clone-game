using TMPro;
using UnityEngine;

public class TransformationUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slotText;

    public TextMeshProUGUI GetSlotText() => slotText;
}
