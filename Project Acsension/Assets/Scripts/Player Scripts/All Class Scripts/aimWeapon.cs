using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class aimWeapon : MonoBehaviour
{
    public Transform weaponPivotPoint;
    private Camera mainCam;
    private Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimWeapon(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            RotateWeapon();
        }
    }

    public void RotateWeapon()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePosition = mousePos - transform.position;

        float rotZ = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
