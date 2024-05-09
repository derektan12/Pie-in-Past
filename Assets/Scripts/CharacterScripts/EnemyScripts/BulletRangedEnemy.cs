using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRangedEnemy : RangedEnemy
{
    public Transform firePointL;
    public Transform firePointR;


    public GameObject bulletPrefab;

    public float bulletForce = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        AcquireTarget();
        originalMaterial = spRend.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        aimBullet();
        
        ActOnTarget();
    }

   
    private void aimBullet()
    {
        //currently changes angle to face direction of movement
        //change to determine if sprite is facing left or right when assets are added

        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        //find angle of direction in degrees --- use to determine the direction the enemy sprites will face
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;


        //Rotate enemy towards the player
        firePointL.rotation = Quaternion.Euler(angle*TimeStop.timeMultiplier *Vector3.forward);
    }
    public override void Attack()
    {
        GameObject bullet;
        if (spRend.flipX)
        {
            bullet = Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, firePointR.position, firePointL.rotation);
        }
        
        bullet.GetComponent<Bullet>().damage= attackDamage;
    }
}
