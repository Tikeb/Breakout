using Assets.Scripts.Controllers;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameManager gameManager;

    private MenuController menuContoller;

    private void Start()
    {
        menuContoller = new MenuController();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            PauseGame();
    }

    public void MainMenu()
    {
        menuContoller.PreviousScene();
    }

    public void PauseGame()
    {
        if (gameManager.isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gameManager.isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gameManager.isPaused = true;
        }
    }

    public void ExitGame()
    {
        menuContoller.ExitGame();
    }
}
