using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLostBall();
    }
}
