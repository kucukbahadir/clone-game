using UnityEngine;

public class InteractUI : MonoBehaviour
{
    void Awake()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);        
    }
}
