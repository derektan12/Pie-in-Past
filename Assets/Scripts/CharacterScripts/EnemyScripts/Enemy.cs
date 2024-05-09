using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : Character
{
    

    public Animator anim;
    

    public float detectionDistance;


    public int collisionDamage = 10;
    public int attackDamage;

    public GameObject target;


    
     


    public float DistanceFromTarget()
    {
        return Vector2.Distance(transform.position, target.transform.position);
    }

    public void RotateTowardsTarget()
    {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        //find angle of direction in degrees --- use to determine the direction the enemy sprites will face
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Debug.Log(angle);
        
        if ((angle > 90 && angle<270) || (angle < -90 && angle > -270))//angle towards left
        {
            spRend.flipX = true;
            
        }
        else//angle towards right
        {
            spRend.flipX = false;
            
        }

        
    }

    public void MoveTowardsTarget()
    {
        //Sets movement of this enemy towards the player
        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, moveSpeed * TimeStop.timeMultiplier * Time.deltaTime);
    }

    public void AcquireTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void ActOnTarget(){}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ouch");
        }
    }*/
}
