using Assets.Enums;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Points;
    public int Hits;
    public BrickType BrickType;
    public bool Unbreakable;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hits <= 1 && !Unbreakable)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerScored(Points);
            Destroy(gameObject);
        }
        Hits--;
    }
}
