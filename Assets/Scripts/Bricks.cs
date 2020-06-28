using Assets.Enums;
using UnityEngine;

public class bricks : MonoBehaviour
{
    public int Points;
    public int Hits;
    public BrickType BrickType;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hits <= 1)
            Destroy(gameObject);
        Hits--;
    }
}
