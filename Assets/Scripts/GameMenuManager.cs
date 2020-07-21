using Assets.Scripts.Controllers;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject nextLevelMenu;
    public GameManager gameManager;
    public BrickManager brickManager;

    private MenuController menuContoller;

    private void Start()
    {
        menuContoller = new MenuController();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            PauseGame(pauseMenu);
    }

    public void MainMenu()
    {
        menuContoller.PreviousScene();
    }

    public void ReplayLevel()
    {
        brickManager.ResetLevel();

        PauseGame(gameOverMenu);

    }

    public void NextLevel()
    {
        brickManager.NextLevel();
    }

    public void TogglePauseMenu()
    {
        PauseGame(pauseMenu);
    }

    public void GameOverMenu()
    {
        PauseGame(gameOverMenu);
    }

    public void NextLevelMenu()
    {
        PauseGame(nextLevelMenu);
    }

    public void PauseGame(GameObject menuItem)
    {
        if (gameManager.isPaused)
        {
            menuItem.SetActive(false);
            Time.timeScale = 1f;
            gameManager.isPaused = false;
        }
        else
        {
            menuItem.SetActive(true);
            Time.timeScale = 0f;
            gameManager.isPaused = true;
        }
    }

    public void ExitGame()
    {
        menuContoller.ExitGame();
    }
}
