using Assets.Enums;
using Assets.Models;
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
            // Temp - do not declare every fkin time!!
            var gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            var brickManager = GameObject.Find("BrickManager").GetComponent<BrickManager>();

            gameManager.PlayerScored(points);
            
            Destroy(gameObject);
            brickManager.remainingBricks--;
        }
        hits--;
    }
}
