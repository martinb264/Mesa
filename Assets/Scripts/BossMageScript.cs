using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMageScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private int Health = 200;
    private int maxHealth;
    private bool Right;
    [SerializeField]
    private BossHealthBarScript healthBarScript;

    bool inFirstStage, inSecondStage = false;
    // Start is called before the first frame update
    void Start()
    {
        Right = true;
       
        inFirstStage = true;
    }

    private void Awake()
    {
        maxHealth = Health;
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 230f)
        {
            Right = false;
        }
        if(transform.position.x < 187f)
        {
            Right = true;
        }

        if(Right == true)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,transform.position.y);
        }

    }

    private void FixedUpdate()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
        if(Health <= 100 && inFirstStage == true)
        {
            speed += 9;
            inFirstStage=false;
            inSecondStage=true; 
        }
        updateHealth(); 
    }

    private void OnEnable()
    {
        Health = maxHealth;
        
        inFirstStage = true;
        inSecondStage = false;
    }

    public void updateHealth()
    {
        float currentHealth = (Health / 100f) / 2f;
        healthBarScript.setSize(currentHealth);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Health += -1;
            updateHealth();
        }
    }
}
