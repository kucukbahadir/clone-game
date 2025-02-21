using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove;
    private PlayerInputMap _playerInputMap;

    private void Awake()
    {
        _playerInputMap = new PlayerInputMap();
    }

    private void OnEnable()
    {
        _playerInputMap.Enable();    
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        var inputValue = _playerInputMap.Gameplay.Move.ReadValue<Vector2>();
        if(inputValue == Vector2.zero) return;
        OnMove?.Invoke(inputValue);
    }

    private void OnDisable()
    {
        _playerInputMap.Disable();
    }
}
