using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public GameObject ball;
    public Vector3 startPosition;

    private float movement;
    private bool jump;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        var velocity = new Vector2(movement * speed, rb.velocity.y);
        rb.velocity = velocity;

        // If the game has not started then move the ball with the paddle
        var ballScript = ball.GetComponent<Ball>();
        if (!ballScript.ballInPlay)
        {
            ball.GetComponent<Rigidbody2D>().velocity = velocity;

            // When the user presses the space bar (jump), launch the ball
            if (jump)
                ballScript.Launch();
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
