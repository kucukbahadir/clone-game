using UnityEngine;
using TMPro;

public class ActionDebugUI : MonoBehaviour
{
    [SerializeField]private BaseUnit baseUnit;
    [SerializeField] private TextMeshProUGUI actionDebugText;

    void Update()
    {
        var action = baseUnit.GetCurrentAction();
        if(action == null)
        {
            actionDebugText.text = "No action";
            return;
        }
        actionDebugText.text = action.ToString();
    }
}
