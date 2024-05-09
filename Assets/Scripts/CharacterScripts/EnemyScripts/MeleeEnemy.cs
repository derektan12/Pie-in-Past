using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeEnemy : Enemy
{
    
    public override void ActOnTarget()
    {
        //If the target is within a certain distance of this enemy, it will move towards the target
        if (DistanceFromTarget() < detectionDistance)
        {
            RotateTowardsTarget();
            MoveTowardsTarget();
            anim.SetTrigger("trigger_move");

        }
        else
        {
            anim.SetTrigger("trigger_idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("touch");
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Player>().TakeDamage(collisionDamage);
        }
    }
    
}
