using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool redSolved = false;
    bool greenSolved = false;
    public GameObject chest;

    // Start is called before the first frame update
    void Start()
    {
        chest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Destroy(gameObject);
        chest.SetActive(true);
    }

    public void SolveRed()
    {
        redSolved = true;
        if(greenSolved == true)
        {
            Open();
        }
    }

    public void SolveGreen()
    {
        greenSolved = true;
        if (redSolved == true)
        {
            Open();
        }
    }
}
