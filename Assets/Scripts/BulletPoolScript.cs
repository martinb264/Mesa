using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{
    public static BulletPoolScript instance;
    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        instance = this;
        bullets = new List<GameObject>();
    }

    public void setNotEnoughBullets(bool parameter)
    {
        notEnoughBulletsInPool = parameter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if(!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if(notEnoughBulletsInPool)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;
    }

    public void resetBullet()
    {
        bullets.Clear();
    }
}
