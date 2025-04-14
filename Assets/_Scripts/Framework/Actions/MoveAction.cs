using System;
using UnityEngine;

public class MoveAction : BaseAction
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    private Vector2 _moveDirection;
    private Rigidbody _rigidBody;


    protected override void Awake()
    {
        base.Awake();
        _rigidBody = GetComponent<Rigidbody>();
    }

    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        _isBusy = true;
        _animator.SetBool("IsWalking", true);
    }

    private void Update()
    {
        if (!_isBusy) return;
        _moveDirection = InputHandler.Instance.GetMoveValue();

        if (_moveDirection == Vector2.zero) 
        {
            _isBusy = false;
            _OnActionComplete?.Invoke();
            _animator.SetBool("IsWalking", false);
            return;
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.linearVelocity = new Vector3(_moveDirection.x,0,_moveDirection.y) * speed * Time.fixedDeltaTime;
        Rotate();
    }

    private void Rotate()
    {
        if (_moveDirection == Vector2.zero) return;
        var targetRotation = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0, _moveDirection.y));
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed);
        _rigidBody.MoveRotation(targetRotation);
    }

    public override void ActionGotInterrupted()
    {
        _isBusy = false;
        _moveDirection = Vector2.zero;
        _animator.SetBool("IsWalking", false);
        _OnActionComplete?.Invoke();
    }
}
