using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    private float timeElapsed;
    const float displayTime = 8;
    TopLayer top;
    BaseMusic bas;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        top = GameObject.Find("Top").GetComponent<TopLayer>();
        bas = GameObject.Find("Base").GetComponent<BaseMusic>();

        top.DeActivate();
        bas.DeActivate();

        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed >= displayTime)
        {
            Destroy(GameObject.Find("Top"));
            Destroy(GameObject.Find("Base"));
            SceneManager.LoadScene(0);
        }
        timeElapsed += Time.deltaTime;
    }
}
