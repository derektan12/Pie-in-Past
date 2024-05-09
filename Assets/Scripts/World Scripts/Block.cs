using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Block : MonoBehaviour
{
    Vector2 move;
    Boolean locked = false;
    static float timestop = 1;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(move * Time.deltaTime * timestop);
    }

    public void Lock()
    {
        locked = true;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;

    }

    public bool IsLocked()
    {
        return locked;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Collider2D collider = collision.collider;

        Vector3 hit = collision.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);

        
            if (collider.name == "Box Collision" || collider.tag == "Block")
            {
                if (Mathf.Approximately(angle, 0))
                {
                    //Down
                    move.y = 0f;
                    move.x = 0f;
                    transform.Translate(0, 0.1f, 0);
                }
                if (Mathf.Approximately(angle, 180))
                {
                    //Up
                    move.y = 0f;
                    move.x = 0f;
                    transform.Translate(0, -0.1f, 0);
                }
                if (Mathf.Approximately(angle, 90))
                {
                    // Sides
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y > 0)
                    { // left side of the player
                        move.y = 0f;
                        move.x = 0f;
                        transform.Translate(0.1f, 0, 0);
                    }
                    else
                    { // right side of the player
                        move.y = 0f;
                        move.x = 0f;
                        transform.Translate(-0.1f, 0, 0);
                    }
                }
            }

        if (!locked)
        {
            if (collider.name == "Player")
            {
                if (Mathf.Approximately(angle, 0))
                {
                    //Down
                    move.y = 4f;
                }
                if (Mathf.Approximately(angle, 180))
                {
                    //Up
                    move.y = -4f;
                }
                if (Mathf.Approximately(angle, 90))
                {
                    // Sides
                    Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                    if (cross.y > 0)
                    { // left side of the player
                        move.x = 4f;
                    }
                    else
                    { // right side of the player
                        move.x = -4f;
                    }
                }
            }
        }*/
    }
}
