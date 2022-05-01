using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossDoorScript : MonoBehaviour
{
    private TilemapRenderer renderer;
    private TilemapCollider2D collider;
    [SerializeField]
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
      renderer = GetComponent<TilemapRenderer>();
        collider = GetComponent<TilemapCollider2D>();
        renderer.enabled = false;
        collider.enabled = false;
        boss.SetActive(false);
        BulletPoolScript.instance.setNotEnoughBullets(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            renderer.enabled = true;
            collider.enabled = true;
            boss.SetActive(true);
            BulletPoolScript.instance.setNotEnoughBullets(true);
            LevelManagerScript.instance.activeBossCam();
        }
    }

    public void restartBoss()
    {
        BulletPoolScript.instance.setNotEnoughBullets(false);
        BulletPoolScript.instance.resetBullet();
        boss.SetActive(false);
        renderer.enabled = false;
        collider.enabled = false;
    }
}
