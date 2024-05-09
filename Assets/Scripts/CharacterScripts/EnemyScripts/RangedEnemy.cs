using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedEnemy : Enemy
{
    public float range;

    public float fireRate;
    private float timeToFire = 0;


    public override void ActOnTarget()
    {
        //If the target is within a certain distance of this enemy, it will rotate and move towards the target
        //until the target is within the range. Then it will attack
        if (DistanceFromTarget() < detectionDistance)
        {
            RotateTowardsTarget();

            if (DistanceFromTarget() > range)//Move towards target until in range
            {
                //Debug.Log("too far");
                anim.SetTrigger("trigger_move");
                MoveTowardsTarget();
            }
            else
            {   
                anim.SetTrigger("trigger_idle");
                if (timeToFire <= 0f) //script to make the enemy fire every couple seconds
                {
                    //Debug.Log("Pew Pew");
                    timeToFire = fireRate;
                    anim.SetTrigger("trigger_attack");
                    Attack();
                    
                }
                else
                {
                    timeToFire -= Time.deltaTime;
                }
            }
        }
    }

    

   
}
