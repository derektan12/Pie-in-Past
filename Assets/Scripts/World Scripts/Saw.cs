using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public GameObject startChain;
    public GameObject endChain;

    public float acceleration;
    public float sawSpeed;
    private float velocity;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        move.y = -sawSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > startChain.transform.position.y)
        {
            velocity -= acceleration;

            move.y = velocity * Time.deltaTime;
        }
        else if(transform.position.y < endChain.transform.position.y)
        {
            velocity += acceleration;

            move.y = velocity * Time.deltaTime;
        }
        else
        {
            if (velocity < 0)
            {
                move.y = -sawSpeed * Time.deltaTime;
            }
            else if (velocity > 0)
            {
                move.y = sawSpeed * Time.deltaTime;
            }
        }


        transform.Translate(move);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.name == "Player")
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(10);
        }
    }
}
