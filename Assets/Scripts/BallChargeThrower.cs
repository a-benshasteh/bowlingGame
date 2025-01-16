using UnityEngine;

public class BallChargeThrower : MonoBehaviour
{
    public float maxCharge = 1000f; // حداکثر نیروی ذخیره‌شده
    public float chargeRate = 500f; // سرعت شارژ نیرو
    private float currentCharge = 0f; // نیروی فعلی
    private Rigidbody rb;
    private bool isCharging = false; // بررسی اینکه کاربر در حال شارژ نیرو است
    private PinManager pinManager; // مرجع به PinManager

    void Start()
    {
        // گرفتن Rigidbody متصل به توپ
        rb = GetComponent<Rigidbody>();

        // گرفتن مرجع به PinManager
        pinManager = FindObjectOfType<PinManager>();
    }

    void Update()
    {
        // شروع شارژ با نگه داشتن کلیک چپ
        if (Input.GetMouseButton(0)) // نگه داشتن کلیک چپ
        {
            isCharging = true;
            currentCharge += chargeRate * Time.deltaTime; // افزایش نیروی ذخیره‌شده
            currentCharge = Mathf.Clamp(currentCharge, 0f, maxCharge); // محدود کردن به حداکثر نیرو
        }

        // پرتاب توپ هنگام رها کردن کلیک چپ
        if (Input.GetMouseButtonUp(0) && isCharging) // رها کردن کلیک چپ
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        // اعمال نیرو به توپ در جهت رو به جلو
        rb.AddForce(transform.forward * currentCharge);
        currentCharge = 0f; // بازنشانی نیروی ذخیره‌شده
        isCharging = false; // غیر فعال کردن حالت شارژ
    }

    void OnGUI()
    {
        // نمایش مقدار نیروی ذخیره‌شده در گوشه صفحه
        GUI.Label(new Rect(10, 10, 300, 20), "Charge: " + Mathf.Round(currentCharge) + "/" + maxCharge);
    }

}
