using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DPSWeapons : MonoBehaviour
{
    public GameObject playerWeapon;
    public Transform muzzle;
    public GameObject bullet;

    private Animator recoil;

    public float bulletVelocity;
    public float reloadTime;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public int currentAmmo, maxAmmo = 30;

    public bool gunEmpty;
    public bool gunLoaded;
    public bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = 30;
    }

    // Update is called once per frame
    void Update()
    {
       if(currentAmmo >=0)
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

    private void FixedUpdate()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= nextTimeToFire)
        {
            if (gunLoaded && canFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
                currentAmmo -= 1;
            }
        }
    }

    public void Reload(InputAction.CallbackContext context) //reload input
    {
        if(context.performed && gunEmpty)
        {
            ReloadWeapon();
            gunLoaded = true;
            gunEmpty = false;
            Debug.Log("Weapon Reloaded");
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {

    }

    private void Fire()
    {
        var fireBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        fireBullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletVelocity, ForceMode.Impulse);
        playerWeapon.GetComponent<Animator>().Play("gunRecoil");
    }

    private void stopRecoil()
    {
        playerWeapon.GetComponent<Animator>().Play("gunSteady");
    }

    private void ReloadWeapon()
    {
        currentAmmo = maxAmmo;
    }
}
