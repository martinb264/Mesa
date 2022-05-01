using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public Transform aimStaffEndPointTransform;
    private Transform aimStaffPositionTransform;
    private float postionX;
    private float postionY;
 
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        aimTransform = transform.Find("Aim");

        aimStaffEndPointTransform = aimTransform.Find("StaffEndPointPosition");
        aimStaffPositionTransform = aimTransform.Find("SpellPosition");

    }

    // Update is called once per frame
    
    void Update()
    {
      HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = new Vector3(postionX, postionY, 0f);
        Vector3 objectPos = LevelManagerScript.instance.activeCam.WorldToScreenPoint(transform.position);
        Vector3 aimDirection = (mousePosition - objectPos).normalized;


        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
      
    }
   
    public void SetMousePosition(float postionX,float positionY)
    {
        this.postionX = postionX;
        this.postionY = positionY;
  
    }

 
   

}
