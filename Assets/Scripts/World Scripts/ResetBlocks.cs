using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBlocks : MonoBehaviour
{
    public GameObject redBlock;
    public GameObject greenBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!redBlock.GetComponent<Block>().IsLocked())
        {
            redBlock.transform.position = new Vector3(-4.51f, -2.35f, redBlock.transform.position.z);
        }
        if (!greenBlock.GetComponent<Block>().IsLocked())
        {
            greenBlock.transform.position = new Vector3(4.5f, -2.35f, greenBlock.transform.position.z);
        }
    }
}
