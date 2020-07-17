using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector3 startPosition;
    public Rigidbody2D rb;
    public GameObject ball;
    public GameObject game;

    private GameManager gameManager;
    private Ball ballScript;
    private float movement;

    private void Start()
    {
        startPosition = transform.position;
        ballScript = ball.GetComponent<Ball>();
        gameManager = game.GetComponent<GameManager>();
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        // If the game has not started then move the ball with the paddle
        if (!gameManager.isStarted)
        {
            // When the user presses the space bar (jump), launch the ball
            if (Input.GetButtonDown("Jump"))
            {
                if (!gameManager.isStarted)
                {
                    ballScript.Launch();
                    gameManager.isStarted = true;
                    gameManager.isPaused = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        var velocity = new Vector2(movement * speed, rb.velocity.y);
        rb.velocity = velocity;

        // If the game has not started then move the ball with the paddle
        if (!gameManager.isStarted)
        {
            ball.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
