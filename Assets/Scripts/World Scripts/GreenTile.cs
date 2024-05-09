using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Green Block")
        {
            Door door = GameObject.Find("Door").GetComponent<Door>();
            door.SolveGreen();

            Block block = GameObject.Find("Green Block").GetComponent<Block>();
            block.Lock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
