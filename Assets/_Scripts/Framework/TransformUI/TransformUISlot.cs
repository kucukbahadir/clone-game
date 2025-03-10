using TMPro;
using UnityEngine;

public class TransformUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI slotText;

    public TextMeshProUGUI GetSlotText() => slotText;
}
