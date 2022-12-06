using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovemnt : MonoBehaviour
{
    public float maxSpeed = 10f;
    private bool flipRight = true;
    public Vector2 force = new Vector2(500, 500);
    Rigidbody2D rb;
    bool inAir;


     private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
    float move = Input.GetAxis("Horizontal");
    GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    

    if (move > 0 && !flipRight)
    {
        Flip();
    }
     else if (move < 0 && flipRight)
     {
        Flip();
     }

     if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            rb.AddForce(force);
        }
    }

    private void Flip()
    {
         flipRight = !flipRight;
         Vector3 theScale = transform.localScale;
         theScale.x *= -1;
         transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        inAir = false;
    }

}