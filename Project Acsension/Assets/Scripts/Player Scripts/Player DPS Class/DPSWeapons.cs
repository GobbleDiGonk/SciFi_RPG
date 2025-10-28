using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DPSWeapons : MonoBehaviour
{
    public GameObject playerWeapon;
    public Transform muzzle;
    public GameObject bullet;

    private Animator dpsAnimator;

    public float bulletVelocity;
    public float reloadTime;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public int currentAmmo, maxAmmo = 30;
    public bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = 30;
        dpsAnimator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(currentAmmo > 0)
        {
            canFire = true;
        }
       else if (currentAmmo == 0)
        {
            canFire = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= nextTimeToFire)
        {
            if (canFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
                currentAmmo -= 1;
                dpsAnimator.SetBool("IsShooting", true);
            }
        }

        if(context.canceled)
        {
            dpsAnimator.SetBool("IsShooting", false);
        }
    }

    public void Reload(InputAction.CallbackContext context) //reload input
    {
        if(context.performed)
        {
            ReloadWeapon();
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {

    }

    private void Fire()
    {
        var fireBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        fireBullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletVelocity, ForceMode.Impulse);
    }

    private IEnumerator ReloadWeapon()
    {
        if(currentAmmo < 30)
        {
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = maxAmmo;
            Debug.Log("Weapon Reloaded");
        }
    }
}
