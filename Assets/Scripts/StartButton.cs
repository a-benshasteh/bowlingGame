using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("new"); // نام دقیق مرحله بعدی را وارد کنید
    }
}
