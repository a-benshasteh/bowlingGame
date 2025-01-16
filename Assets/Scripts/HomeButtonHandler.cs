using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonHandler : MonoBehaviour
{
    // این متد را به دکمه وصل کنید
    public void OnHomeButtonClicked()
    {
        // نام صحنه MainMenu را با نام واقعی صحنه‌تان جایگزین کنید
        SceneManager.LoadScene("mainmenu");
    }
}
