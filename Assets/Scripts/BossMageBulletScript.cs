using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMageBulletScript : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField]
    private float Speed = 10f;
    // Start is called before the first frame update

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection*Speed*Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

  
}
