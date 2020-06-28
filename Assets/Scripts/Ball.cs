using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    //public float angleMultiplier;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed);
        //rb.velocity = new Vector2(0, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            /*
                | y
                |
                |
         --------------- x
                |
                |
                |
             */

            // distance 0 = middle
            // -1 left edge
            // 1 right edge
            // speed = 4
            // if distance = 0 then y = speed, x = 0
            // if distance = 1 then ... 




            float x = HitFactor(transform.position,
                          collision.transform.position,
                          collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            rb.velocity = dir * speed;



            /*

            var dist = this.transform.position.x - GameObject.Find("player").transform.position.x;


            var blah = new Vector2(1, 1);


            var sdf = blah.normalized; // ?


            var currentSpeed = rb.velocity;
            var totalSpeed = speed * 2;// angleMultiplier;

            var x = dist * 8;
            var y = totalSpeed - x;

            var speedCurrentDirection = Mathf.Sqrt((currentSpeed.x * currentSpeed.x) + (currentSpeed.y * currentSpeed.y));

            print($"Blah: {speedCurrentDirection}");


            //print($"Distance: {dist}");

            //print($"Input speed: {speed}");
            //print($"Current speed: x({currentSpeed.x}), y({currentSpeed.y})");
            //print($"Total speed: {totalSpeed}");

            //print($"x: {x}");
            //print($"y: {y}");


            var newx = (dist * totalSpeed);
            var newy = totalSpeed - newx;

            //rb.velocity = new Vector2(newx, newy);



            //rb.velocity = new Vector2(dist * 2, speed.y);
            //rb.velocity = new Vector2(x, y);
            */
        }

        float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
        {
            // ascii art:
            //
            // 1  -0.5  0  0.5   1  <- x value
            // ===================  <- racket
            //
            return (ballPos.x - racketPos.x) / racketWidth * 2;
        }
    }
}
