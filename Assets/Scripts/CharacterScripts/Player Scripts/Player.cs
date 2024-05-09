using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character

{
    private int level = 1;
    private int xp = 0;
    public int maxHP;
    public GameObject xpBar;
    private Canvas levelUp;

    public Rigidbody2D rb;
    Vector2 movement;

    private float invTimer;
    private float invDur;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        maxHP = 100;
        moveSpeed = 10f;
        invDur = 0.5f;
        invTimer = invDur;
        DontDestroyOnLoad(this);
        levelUp = GameObject.Find("Level Up UI").GetComponent<Canvas>();
        levelUp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting both the horizontal and vertical movements 
        movement.x = Input.GetAxis("Horizontal"); 
        movement.y = Input.GetAxis("Vertical");

        if (invTimer < invDur)
        {
            invTimer += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }
    public virtual void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public override void Attack()
    {

    }
    public override void TakeDamage(float damage) 
    {
        if (invTimer >= invDur)
        {
            //health -= damage;
            invTimer = 0;
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(5);
            Destroy(gameObject);
        }

        GameObject hpBar = GameObject.Find("HP Holder");
        hpBar.GetComponent<HPBar>().Change(this);
    }
    public void TimeStop()
    {

    }
    public void GainXP(int newXP)
    {
        xp += newXP;

        if (xp >= 20)
        {
            LevelUp();
            xp = xp % 20;
        }
    }

    public void LevelUp()
    {
        level++;
        levelUp.enabled = true;
    }
}
