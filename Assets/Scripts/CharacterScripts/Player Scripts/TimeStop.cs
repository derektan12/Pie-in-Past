using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    public static float timeMultiplier = 1;

    public static float duration = 5f;

    public static float cooldown = 7f;
    float timeToNextUse;

    Boolean canCountDown = false;
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeToNextUse);
        if (timeToNextUse <= 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Debug.Log("ZAA WARUDOO");

                SlowTime();
                Invoke("ResumeTime", duration);

            }
            
        }
        else if (canCountDown)
        {
            //Debug.Log("on cool");
            timeToNextUse -= Time.deltaTime;
        }
        
    }

    void SlowTime()
    {
        timeMultiplier = 0.1f;
    }

    void ResumeTime()
    {
        timeMultiplier = 1f;
        timeToNextUse = cooldown;
        canCountDown = true;
    }

}
