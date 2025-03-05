using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool invert;
    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        var directionToCamera = (_cameraTransform.position - transform.position).normalized;
        transform.LookAt(transform.position + directionToCamera * -1);
        // if (invert)
        // {
        //     var directionToCamera = (_cameraTransform.position - transform.position).normalized;
        //     transform.LookAt(transform.position + directionToCamera * -1);
        // }
        // else
        // {
        //     transform.LookAt(_cameraTransform);
        // }
    }
}
