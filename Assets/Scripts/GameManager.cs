using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Lives;
    public GameObject Ball;
    public GameObject Player;
    public GameObject BrickManager;

    private int Score = 0;
    private int StartingLives;

    private void Start()
    {
        StartingLives = Lives;
    }

    public void PlayerScored(int points)
    {
        Score += points;
        UpdateScore();
    }

    public void PlayerLostBall()
    {
        if (Lives <= 0)
        {
            Lives = StartingLives;
            Score = 0;
            UpdateScore();
            ResetLives();
            ResetPosition(true);
        }
        else
        {
            ResetPosition(false);
            RemoveLife();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ResetPosition(bool resetLevel)
    {
        Ball.GetComponent<Ball>().Reset();
        Player.GetComponent<Player>().Reset();

        if (resetLevel)
            BrickManager.GetComponent<BrickManager>().ResetLevel();
    }

    private void UpdateScore()
    {
        GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>().text = Score.ToString();
    }

    private void ResetLives()
    {
        GameObject.Find("LifeThreeImg").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("LifeTwoImg").GetComponent<CanvasGroup>().alpha = 1;
        GameObject.Find("LifeOneImg").GetComponent<CanvasGroup>().alpha = 1;
    }

    private void RemoveLife()
    {
        switch (Lives)
        {
            case 3:
                GameObject.Find("LifeThreeImg").GetComponent<CanvasGroup>().alpha = 0;
                break;
            case 2:
                GameObject.Find("LifeTwoImg").GetComponent<CanvasGroup>().alpha = 0;
                break;
            case 1:
                GameObject.Find("LifeOneImg").GetComponent<CanvasGroup>().alpha = 0;
                break;
        }
        Lives--;
    }
}
