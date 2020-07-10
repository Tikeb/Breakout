using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;
    public GameObject ball;
    public GameObject player;
    public GameObject brickManager;

    private int Score = 0;
    private int StartingLives;

    private void Start()
    {
        StartingLives = lives;
    }

    public void PlayerScored(int points)
    {
        Score += points;
        UpdateScore();
    }

    public void PlayerLostBall()
    {
        if (lives <= 0)
        {
            lives = StartingLives;
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

    private void ResetPosition(bool resetLevel)
    {
        ball.GetComponent<Ball>().Reset();
        player.GetComponent<Player>().Reset();

        if (resetLevel)
            brickManager.GetComponent<BrickManager>().ResetLevel(0);
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
        switch (lives)
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
        lives--;
    }
}
