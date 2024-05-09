using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int index;
    public TextMeshPro foundText;
    public Animator animator;
    private bool done;
    private bool startTimer;
    private float timer;
    private float enabledTime;

    // Start is called before the first frame update
    void Start()
    {
        foundText.enabled = false;
        enabledTime = 3;
        timer = 0;
        startTimer = false;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTimer)
        {
            timer += Time.deltaTime;
        }
        if(timer >= enabledTime)
        {
            foundText.enabled = false;
            startTimer = false;
            timer = 0;
            done = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!done)
        {
            foundText.enabled = true;
            startTimer = true;
            animator.SetTrigger("openTrig");
        }
    }
}
