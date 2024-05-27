using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMeleeEnemie : MeleeEnemy
{
    private void Start()
    {
        AcquireTarget();
        originalMaterial = spRend.material;
        maxHP = 100;
        health = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        base.ActOnTarget();
    }

    //add method to back up after hitting
    private void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log("touch");
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("trigger_attack");
            collision.gameObject.GetComponent<Player>().TakeDamage(collisionDamage);
        }
    }
}
