using Assets.Enums;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits;
    public int points;
    public BrickType brickType;
    public bool unbreakable;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hits <= 1 && !unbreakable)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(points);
            Destroy(gameObject);
        }
        hits--;
    }
}
