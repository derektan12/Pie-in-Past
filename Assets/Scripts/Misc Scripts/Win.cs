using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
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
        player = GameObject.Find("Player").GetComponent<Player>();
        player.transform.position = new Vector3(-5.6f,-1.8f,-2);

        top.DeActivate();
        bas.DeActivate();

        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed >= displayTime)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            Destroy(GameObject.Find("Top"));
            Destroy(GameObject.Find("Base"));
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene(0);
        }
        timeElapsed += Time.deltaTime;
    }
}
