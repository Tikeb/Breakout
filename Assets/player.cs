using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    private float movement;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }
}
