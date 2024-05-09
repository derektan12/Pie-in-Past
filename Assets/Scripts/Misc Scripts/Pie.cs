using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Pie : MonoBehaviour
{
    public AnimationCurve curve;
    public float yPos;
    public bool end;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yPos + curve.Evaluate(Time.time % curve.length), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!end && collision.name == "Player") { 
            Portal portal = GameObject.Find("Portal").GetComponent<Portal>();
            portal.Activate();
            Destroy(gameObject);
        }
    }
}
