using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSetScript : MonoBehaviour
{


    // Start is called before the first frame update

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            LevelManagerScript.instance.setRespawnPoint();
        }
    }

}
