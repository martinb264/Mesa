using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
   
    [SerializeField]
    private Transform weaponEndPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float jumpforce;
    private Rigidbody2D rb;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    private bool isGrounded = false;
    private float movementX;
    private float movementY;
    private float positionX;
    private float positionY;
    private bool allowDoubleJump = false;

    private Animator anim;

    private readonly int speedHash = Animator.StringToHash("Speed");

    // Start is called before the first frame update


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        

    }
    void OnMove(InputValue movementValue)
    {
        Debug.Log("Move");
        Vector2 movementVector = movementValue.Get<Vector2>();
        Debug.Log(movementVector.x);
        movementX = movementVector.x;
        movementY = movementVector.y;


    }

    void OnJump()
    {
        if (isGrounded || allowDoubleJump == true && isGrounded == false)
        {
            Debug.Log("Jump");
            rb.velocity = Vector2.up * jumpforce;
            allowDoubleJump = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX,movementY);
        rb.AddForce(movement * speed);


        flipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log(isGrounded);

        anim.SetFloat(speedHash, speed);
    }
    
    void OnMousePosition(InputValue mousePosition)
    {
        Vector2 position = mousePosition.Get<Vector2>();
        positionX = position.x;
        positionY = position.y;
        GetComponent<PlayerAimWeapon>().SetMousePosition(positionX,positionY);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoubleJumpCube"))
        {
            allowDoubleJump = true;
        }
    }

    public void OnFire()
    {
        if (LevelManagerScript.instance.isAlive)
        {
            Debug.Log("FIRE!");

            Instantiate(bulletPrefab, weaponEndPoint.position, weaponEndPoint.rotation);
        }

    }
    
    void flipPlayer()
    {
        if(movementX < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0,180));
        }
        if(movementX > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
    }

}
