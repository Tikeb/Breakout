using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        print("Play game..");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        print($"Settings");
    }

    public void ExitGame()
    {
        print($"Game has exited");
        Application.Quit();
    }
}
