using UnityEngine;

public class ffcd : MonoBehaviour
{
    // Amplitude of the rotation (maximum rotation angle)
    public float amplitude = 15f;
    // Speed of the oscillation
    public float speed = 2f;
    // Axis of rotation
    public Vector3 rotationAxis = Vector3.up;

    private Quaternion initialRotation;

    void Start()
    {
        // Store the initial rotation
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Calculate the new rotation angle
        float angle = amplitude * Mathf.Sin(Time.time * speed);
        // Create a rotation based on the angle and axis
        Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);
        // Apply the rotation while maintaining the initial rotation as the base
        transform.rotation = initialRotation * rotation;
    }
}
