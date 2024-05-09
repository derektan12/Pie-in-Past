using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private float lifeTime = 3f;
    private readonly float speed = 5f;
    
    private Rigidbody2D rb;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, lifeTime);//bullet is destroyes after lifetime runs out
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = TimeStop.timeMultiplier* speed*transform.up ;//bullet flies forward
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ouch:" + collision.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hahahahah");
            collision.GetComponent<Player>().TakeDamage(damage);
            Destroy(this.gameObject);
        } else if (collision.gameObject.CompareTag("Bullet Wall"))
        {
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.GetComponent<Character>().TakeDamage(damage*0.3f);
            Destroy(this.gameObject);
        }

    }
}
