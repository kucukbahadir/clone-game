using System;
using UnityEngine;

public class MoveAction : BaseAction
{
    [SerializeField] private float speed;
    private Vector2 _moveDirection;
    private Rigidbody _rigidBody;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        _isBusy = true;
    }

    private void Update()
    {
        if (!_isBusy) return;
        _moveDirection = InputHandler.Instance.GetMoveValue();

        if (_moveDirection == Vector2.zero) 
        {
            _isBusy = false;
            _OnActionComplete?.Invoke();
            return;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector3(_moveDirection.x,0,_moveDirection.y) * speed;
    }
}
