using UnityEngine;
using UnityEngine.InputSystem;

public class DPSWeapons : MonoBehaviour
{
    public GameObject playerWeapon;
    public Transform muzzle;
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
        if (context.canceled)
        {
            if(gunLoaded = true &&(canFire = true)) 
            {
                Fire();
                currentAmmo -= 1;
            }
        }
    }

    public void Reload(InputAction.CallbackContext context) //reload input
    {
        if(context.performed)
        {
            ReloadWeapon();
            gunLoaded = true;
            gunEmpty = false;
            Debug.Log("Weapon Reloaded");
        }
    }

    private void Fire()
    {
        var fireBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        fireBullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletVelocity, ForceMode.Impulse);
    }

    private void ReloadWeapon()
    {
        currentAmmo = maxAmmo;
    }
}
