using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class TankShotgun : MonoBehaviour
{

    public GameObject playerWeapon;
    public Transform muzzleTop;
    public Transform muzzleMiddle;
    public Transform muzzleBottom;
    public GameObject bullet;

    public float bulletVelocity;
    public float reloadTime;

    public int currentAmmo, maxAmmo = 30;

    public bool gunEmpty;
    public bool gunLoaded;
    public bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(gunLoaded && canFire)
            {
                StartCoroutine(Fire());
                currentAmmo -= 1;
            }
        }
    }

    private IEnumerator Fire()
    {
        var fireBulletTop = Instantiate(bullet, muzzleTop.position, Quaternion.identity);
        var fireBulletMiddle = Instantiate(bullet, muzzleMiddle.position, Quaternion.identity);
        var fireBulletBottom = Instantiate(bullet, muzzleBottom.position, Quaternion.identity);
        fireBulletTop.GetComponent<Rigidbody>().AddForce(muzzleTop.transform.forward * bulletVelocity, ForceMode.Impulse);
        fireBulletMiddle.GetComponent<Rigidbody>().AddForce(muzzleMiddle.transform.forward * bulletVelocity, ForceMode.Impulse);
        fireBulletBottom.GetComponent<Rigidbody>().AddForce(muzzleBottom.transform.forward * bulletVelocity, ForceMode.Impulse);
        yield return new WaitForSeconds(1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo >= 0)
        {
            gunLoaded = true;
            gunEmpty = false;
            canFire = true;
        }
        else if (currentAmmo <= 0)
        {
            gunLoaded = true;
            gunEmpty = false;
            canFire = true;
        }
    }
}
