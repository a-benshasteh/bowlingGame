using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // این متد به دکمه استارت اختصاص می‌یابد
    public void StartGame()
    {
        // بارگذاری سن جدید با نام آن
        SceneManager.LoadScene("GameScene"); // نام سن بازی را اینجا وارد کنید
    }
}
