using Assets.Scripts.Controllers;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private MenuController menuContoller;

    private void Start()
    {
        menuContoller = new MenuController();
    }

    public void PlayGame()
    {
        menuContoller.NextScene();
    }

    public void Settings()
    {
        Debug.Log($"Settings");
    }

    public void ExitGame()
    {
        menuContoller.ExitGame();
    }
}
