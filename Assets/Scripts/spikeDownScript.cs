using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDownScript : MonoBehaviour
{
    Rigidbody2D rb;
 
    Vector2 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            rb.gravityScale = 150;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            if (rb.isKinematic == false)
            {
                resetPosition();
            }
        }
    }

    private void resetPosition()
    {
        Debug.Log("reset");
        gameObject.transform.position = originalPos;
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
