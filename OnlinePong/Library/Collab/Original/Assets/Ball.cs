using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float speed = 10.0f;

    public void Start()
    {
        if(GameObject.Find("Eject").GetComponent<Directions>().goingUp)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = - Vector2.up * speed;
        }
    }

    private void Update()
    { }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketLength)
    {
        return (ballPos.x - racketPos.x) / racketLength;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.position.y == GameObject.Find("Spawn1").GetComponent<Transform>().transform.position.x && col.gameObject.tag == "Player")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.transform.position.y == GameObject.Find("Spawn2").GetComponent<Transform>().transform.position.x && col.gameObject.tag == "Player")
        {
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, -1).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

}