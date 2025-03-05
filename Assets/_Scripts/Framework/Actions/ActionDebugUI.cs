using UnityEngine;
using TMPro;

public class ActionDebugUI : MonoBehaviour
{
    [SerializeField] private BaseUnit baseUnit;
    [SerializeField] private TextMeshProUGUI actionDebugText;
    [SerializeField] private bool UseDebugUI = true;

    void Update()
    {
        if(!UseDebugUI)
        {
            actionDebugText.text = "";
            return;
        }

        var action = baseUnit.GetCurrentAction();
        if(action == null)
        {
            actionDebugText.text = "No action";
            return;
        }
        actionDebugText.text = action.ToString();
    }
}
