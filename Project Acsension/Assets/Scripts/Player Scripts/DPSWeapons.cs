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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (currentAmmo >= 0)
        {
            gunLoaded = true;
        }
        else if (currentAmmo == 0)
        {
            gunLoaded = false;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed && (gunLoaded = true))
        {
            Fire();
            currentAmmo -= 1;
        }
    }

    public void Reload(InputAction.CallbackContext context) //reload input
    {
        if(context.performed)
        {
            ReloadWeapon();
            gunLoaded = true;
        }
    }

    private void Fire()
    {
        var fireBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        fireBullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletVelocity, ForceMode.Impulse);
    }

    private void ReloadWeapon()
    {
        int reloadAmount = currentAmmo - maxAmmo;
    }
}
