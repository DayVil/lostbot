using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float yOffset; // Vertical offset
    private readonly Manager _manager = Manager.GetInstance;

    void FixedUpdate()
    {
        if (_manager.StartGame)
        {
            // Calculate the target position in world space
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);

            // Smoothly follow the target in x and y directions
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        }
    }
}
