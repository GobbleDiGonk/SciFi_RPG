using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target; // TPPlayer
    [SerializeField] Vector3 offset = new Vector3(0, 2, -10);
    [SerializeField] float smoothTime = 0.15f;

    Vector3 velocity;

   void LateUpdate()
    {
        if (!target) return;
        
        Vector3 desired = new Vector3(target.position.x, target.position.y, 0f) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);
    }
}
