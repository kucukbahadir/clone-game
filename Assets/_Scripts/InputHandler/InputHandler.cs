using System;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviourSingleton<InputHandler>
{
    public EventHandler<ActionEventArgs<object>> OnAnyInput;
    private PlayerInputMap _playerInputMap;

    protected override void Awake()
    {
        base.Awake();

        _playerInputMap = new PlayerInputMap();
    }

    private void OnEnable()
    {
        _playerInputMap.Enable();    
    }

    private void Update()
    {
        HandleMovementInput();
        HandleCloneInput();
    }

    private void HandleMovementInput()
    {
        var inputValue = _playerInputMap.Gameplay.Move.ReadValue<Vector2>();
        if(inputValue == Vector2.zero) return;
        OnAnyInput?.Invoke(this, new ActionEventArgs<object>(inputValue, ActionTypes.Move));
    }

    private void HandleCloneInput()
    {
        if (!_playerInputMap.Gameplay.Clone.WasPressedThisFrame()) return;

        OnAnyInput?.Invoke(this, new ActionEventArgs<object>(null, ActionTypes.Clone));
    }

    private void OnDisable()
    {
        _playerInputMap.Disable();
    }
}
