using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public float throwForce = 500f; // نیروی پرتاب
    private Rigidbody rb;
    private bool hasThrown = false; // برای بررسی اینکه توپ پرتاب شده است یا نه

    void Start()
    {
        // گرفتن Rigidbody متصل به توپ
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // بررسی کلیک چپ ماوس و اینکه توپ هنوز پرتاب نشده است
        if (Input.GetMouseButtonDown(0) && !hasThrown) // 0 برای کلیک چپ
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        // اعمال نیرو به توپ در جهت رو به جلو
        rb.AddForce(transform.forward * throwForce);
        hasThrown = true; // تنظیم پرچم که توپ پرتاب شده است
    }
}
