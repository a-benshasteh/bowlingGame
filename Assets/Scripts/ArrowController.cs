using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private const float RotationSpeed = 30f; // Rotation speed in degrees per second
    private const float ScaleChangeSpeed = 1f; // Scale change speed per second
    private const float MaxScaleZ = 2f; // Maximum Z scale
    private const float MinScaleZ = 0.1f; // Minimum Z scale

    void Update()
    {
        HandleRotation();
        HandleScaling();
    }

    private void HandleRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down, Time.deltaTime * RotationSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed);
        }
    }

    private void HandleScaling()
    {
        float scaleZ = transform.localScale.z;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            scaleZ = Mathf.Min(scaleZ + ScaleChangeSpeed * Time.deltaTime, MaxScaleZ);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            scaleZ = Mathf.Max(scaleZ - ScaleChangeSpeed * Time.deltaTime, MinScaleZ);
        }

        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scaleZ);
    }
}
