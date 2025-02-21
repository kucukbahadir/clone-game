using System;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviourSingleton<InputHandler>
{
    public EventHandler<ActionEventArgs> OnAnyInput;
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
        if(_playerInputMap.Gameplay.Move.ReadValue<Vector2>() == Vector2.zero) return;
        OnAnyInput?.Invoke(this, new ActionEventArgs(ActionTypes.Move));
    }

    private void HandleCloneInput()
    {
        if (!_playerInputMap.Gameplay.Clone.WasPressedThisFrame()) return;

        OnAnyInput?.Invoke(this, new ActionEventArgs(ActionTypes.Clone));
    }

    public Vector2 GetMoveValue()
    {
        return _playerInputMap.Gameplay.Move.ReadValue<Vector2>();
    }

    private void OnDisable()
    {
        _playerInputMap.Disable();
    }
}
