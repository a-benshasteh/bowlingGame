using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadSceneAsync("start");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
