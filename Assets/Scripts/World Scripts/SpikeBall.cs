using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public GameObject centerChain;
    public float angularSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerChain.transform.position, Vector3.forward, angularSpeed * Time.deltaTime);
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
