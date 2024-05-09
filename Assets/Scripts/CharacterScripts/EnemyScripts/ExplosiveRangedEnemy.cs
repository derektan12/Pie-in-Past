using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRangedEnemy : RangedEnemy
{
    public Transform attackDestination;//make a transform that can be moved to allow for targetting

    public GameObject aoeIndicator;
    public GameObject explosionEffect;

    public static float explosionRadius = 5;

    
    private void Start()
    {
        AcquireTarget();
        originalMaterial = spRend.material;
        attackDamage = 40;
    }

    private void Update()
    {
        base.ActOnTarget();
    }

    public override void Attack()
    {
        attackDestination.position = target.transform.position;

        
        GameObject indicator = Instantiate(aoeIndicator, attackDestination.position, attackDestination.rotation);
        indicator.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
        

        GameObject effect = Instantiate(explosionEffect, attackDestination.position, attackDestination.rotation,indicator.transform);
        effect.GetComponent<ExplosionBehaviour>().damage = attackDamage;
    }
   
}
