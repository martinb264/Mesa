using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJump : MonoBehaviour
{
    public float respawnTimer;
    public float delay = 5f;
    private bool collected = false;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private BoxCollider2D collider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.Sleep();
            rbSprite.enabled = false;
            collider.enabled = false;


            collected = true;
        }
    }

    private void FixedUpdate()
    {
        if(collected == true)
        {
            respawnTimer += Time.deltaTime;
           
            if(respawnTimer > delay)
            {
                respawn();
                collected = false;
            }
        }
       
    }


    private void respawn()
    {
        respawnTimer = 0;
        rb.IsAwake();
        rbSprite.enabled = true;
        collider.enabled = true;

    }
}
