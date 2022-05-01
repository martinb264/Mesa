using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorBladeScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0,0,360*speed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("Razor");
        }
    }
}
