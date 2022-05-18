using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.13f;
    public Vector3 offset;

    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;
    
    void FixedUpdate()
    {
        _desiredPosition = target.position + offset;
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed);
        transform.position = _smoothedPosition;
        transform.LookAt(target);
    }    
}
