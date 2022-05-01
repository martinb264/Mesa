using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBossFireBullet : MonoBehaviour
{

    [SerializeField]
    private int BulletAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire2", 0f, 10f);
        InvokeRepeating("Fire", 0f, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / BulletAmount;
        float angle = startAngle;

        for (int i = 0; i < BulletAmount; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 BulletDirection = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPoolScript.instance.getBullet();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<BossMageBulletScript>().SetMoveDirection(BulletDirection);

                angle += angleStep;
            }
        }
    }
    private void Fire2()
    {
        float angleStep = (endAngle - startAngle) / BulletAmount;
        float angle = startAngle;

            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 BulletDirection = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = BulletPoolScript.instance.getBullet();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<BossMageBulletScript>().SetMoveDirection(BulletDirection);

                angle += 10f;
        }
    }
    
}
