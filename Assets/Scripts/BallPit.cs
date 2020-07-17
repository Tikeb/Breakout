using UnityEngine;

public class BallPit : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.PlayerLostBall();
    }
}
