using Assets.Enums;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType PowerUpType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "bottom-void")
        {
            Destroy(gameObject);
            //Debug.Log($"Missed powerup of {this.name}");
        }
        else if (collision.gameObject.name == "player")
        {
            Destroy(gameObject);
            //Debug.Log($"Gained powerup of {this.name} :D");
        }
    }
}
