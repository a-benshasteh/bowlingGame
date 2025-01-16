using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // توپ که دوربین باید دنبال کند
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); // فاصله ثابت دوربین از توپ
    [SerializeField] private float smoothSpeed = 0.125f; // سرعت نرمی حرکت دوربین

    private void LateUpdate()
    {
        if (target == null) return;

        // محاسبه موقعیت هدف دوربین
        Vector3 desiredPosition = target.position + offset;

        // نرمی حرکت دوربین به سمت موقعیت هدف
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // تنظیم موقعیت دوربین
        transform.position = smoothedPosition;

        // دوربین همیشه به سمت توپ نگاه می‌کند
        transform.LookAt(target);
    }
}
