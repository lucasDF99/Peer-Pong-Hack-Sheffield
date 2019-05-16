﻿using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
//using System.Collections.Generic;
//using System.Collections;

public class PaddleControls : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public float boundX = 2.25f;
    private Rigidbody2D rb2d;

    //[SerializeField]
    private float speed=10.0f;
    /*
    void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            float movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 10.0f);
        }
    }
    */

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if (isLocalPlayer)
        //{
            var vel = rb2d.velocity;
            if (Input.GetKey(moveLeft))
            {
                vel.x = speed;
            }
            else if (Input.GetKey(moveRight))
            {
                vel.x = -speed;
            }
            else
            {
                vel.x = 0;
            }
            rb2d.velocity = vel;

            var pos = transform.position;
            if (pos.x > boundX)
            {
                pos.x = boundX;
            }
            else if (pos.x < -boundX)
            {
                pos.x = -boundX;
            }
            transform.position = pos;
       // }

        
    }
}
