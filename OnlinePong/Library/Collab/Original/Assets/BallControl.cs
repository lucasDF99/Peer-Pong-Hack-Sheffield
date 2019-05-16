using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0, 200));
        }
        else
        {
            rb2d.AddForce(new Vector2(-0, -200));
        }
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void ResetBall()
    {
        rb2d.velocity = new Vector2(0, 0);
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x =  (rb2d.velocity.x / 2.0f) + (coll.collider.attachedRigidbody.velocity.x / 3.0f);
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
            float rand = Random.Range(0, 10);
            if (rand > 8)
            {

            }

        }
        else if(coll.collider.CompareTag("TopWall")){
            GameManager.Score("TopWall");
        }
        else if (coll.collider.CompareTag("BottomWall"))
        {
            GameManager.Score("BottomWall");
        }
    }

}