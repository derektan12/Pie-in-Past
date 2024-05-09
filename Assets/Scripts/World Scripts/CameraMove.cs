using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float yMove;
    public float xMove;
    public bool activateLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            cam.transform.position = new Vector3(xMove, yMove, -10);
            if (activateLayer)
            {
                TopLayer top = GameObject.Find("Top").GetComponent<TopLayer>();
                top.Activate();
            }
            else
            {
                TopLayer top = GameObject.Find("Top").GetComponent<TopLayer>();
                top.DeActivate();
            }
        }
    }
}
