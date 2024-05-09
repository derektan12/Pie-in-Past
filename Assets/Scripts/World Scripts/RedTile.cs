using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Red Block")
        {
            Door door = GameObject.Find("Door").GetComponent<Door>();
            door.SolveRed();

            Block block = GameObject.Find("Red Block").GetComponent<Block>();
            block.Lock();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
