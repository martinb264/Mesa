using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject deathTextObject;
    [SerializeField]
    private GameObject deathTextObject2;
    private bool hasCollide = false;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            if (hasCollide == false)
            {
                deathTextObject.SetActive(true);
                deathTextObject2.SetActive(true);

                hasCollide = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                spriteRenderer.enabled = false;
                collider.enabled = false;
                LevelManagerScript.instance.isAlive = false;
                LevelManagerScript.instance.startDeathMusic();
              
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (hasCollide == false)
            {
                deathTextObject.SetActive(true);
                deathTextObject2.SetActive(true);

                hasCollide = true;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                spriteRenderer.enabled = false;
                collider.enabled = false;
                LevelManagerScript.instance.isAlive = false;
                LevelManagerScript.instance.startDeathMusic();
            }
        }
    }

    private void OnRespawn()
    {
        
        deathTextObject.SetActive(false);
        deathTextObject2.SetActive(false);

        Destroy(gameObject);
        LevelManagerScript.instance.isAlive = false;
        LevelManagerScript.instance.Respawn();
    }
    // Start is called before the first frame update
    void Start()
    {
        deathTextObject.SetActive(false);
        deathTextObject2.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
