using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserScript : MonoBehaviour
{
    [SerializeField]
    private float defDistanceRay = 100;
  
    public LineRenderer lineRenderer;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }
    private void Update()
    {
        shootLaser();
    }
    public void shootLaser()
    {
        if (Physics2D.Raycast(transform.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);
            draw2DRay(transform.position, hit.point);

        }
        {
            draw2DRay(transform.position,transform.right * defDistanceRay);
        }
    }

    private void draw2DRay(Vector2 startpos, Vector2 endpos)
    {
        lineRenderer.SetPosition(0, startpos);
        lineRenderer.SetPosition(1, endpos);
    }
}
