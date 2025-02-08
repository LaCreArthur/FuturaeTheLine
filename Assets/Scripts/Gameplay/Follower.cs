using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 0.125f;

    [SerializeField] bool freezeX;
    [SerializeField] bool freezeY;
    [SerializeField] bool freezeZ;


    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        if (freezeX) desiredPosition.x = transform.position.x;
        if (freezeY) desiredPosition.y = transform.position.y;
        if (freezeZ) desiredPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
