using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveMeleeEnemy : MeleeEnemy
{
    

    public float ignitionDistance;
    public static float explosionRadius = 5;

    public Transform center;
    public GameObject aoeIndicator;
    public GameObject explosionEffect;

    private Boolean hasExploded = false;
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
        if (!hasExploded && DistanceFromTarget()<ignitionDistance)
        {
            //explode
            hasExploded = true;
            anim.SetTrigger("trigger_explode");
            GameObject indicator = Instantiate(aoeIndicator, center.position, center.rotation,transform);
            indicator.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);  

            GameObject effect = Instantiate(explosionEffect, center.position, center.rotation,transform);
            effect.GetComponent<ExplosionBehaviour>().explosionRadius *= 5;
            effect.GetComponent<ExplosionBehaviour>().growth *= 5;
            effect.GetComponent<ExplosionBehaviour>().damage = attackDamage;


            GameObject finalTarget = Instantiate(new GameObject("explosionPoint"), target.transform.position, target.transform.rotation);
            //make an empty gameObject to set as the new target
            target = finalTarget;
            moveSpeed *= 1.3f;
            
        }
        base.ActOnTarget();
    }
}
