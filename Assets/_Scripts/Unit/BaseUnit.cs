using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    public void Move(Vector2 moveDirection)
    {
        transform.Translate(new Vector3(moveDirection.x,0,moveDirection.y) * moveSpeed * Time.deltaTime);
    }

    
}
