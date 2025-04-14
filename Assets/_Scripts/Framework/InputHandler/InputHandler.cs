using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviourSingleton<InputHandler>
{
    public EventHandler<ActionTypes> OnAnyActionInput;
    public EventHandler OnSwitchUnitInput;
    private PlayerInputMap _playerInputMap;

    protected override void Awake()
    {
        base.Awake();

        if(_playerInputMap != null) return;
        _playerInputMap = new PlayerInputMap();
    }

    private void OnEnable() => _playerInputMap.Enable();

    private void OnLevelWasLoaded(int level) => _playerInputMap.Enable();


    private void Update()
    {
        HandleMovementInput();
        HandleCloneInput();
        HandleSwitchUnitInput();
        HandleTransformInput();
        HandleInteractInput();
    }

    private void HandleMovementInput()
    {
        if(_playerInputMap.Gameplay.Move.ReadValue<Vector2>() == Vector2.zero) return;

        OnAnyActionInput?.Invoke(this, ActionTypes.Move);
    }

    private void HandleCloneInput()
    {
        if (!_playerInputMap.Gameplay.Clone.WasPressedThisFrame()) return;

        OnAnyActionInput?.Invoke(this, ActionTypes.Clone);
    }

    private void HandleTransformInput()
    {
        if (!_playerInputMap.Gameplay.Transform.WasPressedThisFrame()) return;

        OnAnyActionInput?.Invoke(this,ActionTypes.Transform);
    }
    
    private void HandleInteractInput()
    {
        if (!_playerInputMap.Gameplay.Interact.WasPressedThisFrame()) return;
        
        OnAnyActionInput?.Invoke(this,ActionTypes.Interact);
    }

    private void HandleSwitchUnitInput()
    {
        if (!_playerInputMap.Gameplay.SwitchUnit.WasPressedThisFrame()) return;

        OnSwitchUnitInput?.Invoke(this,null);
    }

    public Vector2 GetMoveValue() => _playerInputMap.Gameplay.Move.ReadValue<Vector2>();

    //private void OnDisable() => _playerInputMap.Disable();
}
