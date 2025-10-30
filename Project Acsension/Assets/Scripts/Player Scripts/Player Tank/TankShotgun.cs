using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class TankShotgun : MonoBehaviour
{
    public Transform muzzleTop;
    public Transform muzzleMiddle;
    public Transform muzzleBottom;
    public GameObject bullet;

    public float bulletVelocity;
    public float reloadTime;

    public int currentAmmo, maxAmmo = 8;

    public bool canFire;
    public bool isPumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(canFire)
            {
                StartCoroutine(Fire());
                currentAmmo -= 1;
            }
        }
    }

    public void Reload(InputAction.CallbackContext context)
    {
        StartCoroutine(ReloadWeapon());
    }

    private IEnumerator Fire()
    {
        if(!isPumping)
        {
            var fireBulletTop = Instantiate(bullet, muzzleTop.position, muzzleTop.rotation);
            var fireBulletMiddle = Instantiate(bullet, muzzleMiddle.position, muzzleMiddle.rotation);
            var fireBulletBottom = Instantiate(bullet, muzzleBottom.position, muzzleBottom.rotation);
            fireBulletTop.GetComponent<Rigidbody>().AddForce(muzzleTop.transform.forward * bulletVelocity, ForceMode.Impulse);
            fireBulletMiddle.GetComponent<Rigidbody>().AddForce(muzzleMiddle.transform.forward * bulletVelocity, ForceMode.Impulse);
            fireBulletBottom.GetComponent<Rigidbody>().AddForce(muzzleBottom.transform.forward * bulletVelocity, ForceMode.Impulse);
            isPumping = true;
            yield return new WaitForSeconds(1.5f);
            isPumping = false;
        }   
    }

    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        Debug.Log("Weapon Reloaded");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo >= 0)
        {
            canFire = false;
        }
        else if (currentAmmo <= 0)
        {
            canFire = true;
        }
    }
}
