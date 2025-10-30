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
        dpsAnimator.GetComponent<Animator>();
        currentAmmo = 30;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(currentAmmo >0)
        {
            canFire = true;
        }
       else if (currentAmmo <= 0)
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
                Debug.Log("Is shooting bullets");
            }
        }
    }

    public void Reload(InputAction.CallbackContext context) //reload input
    {
        StartCoroutine(ReloadWeapon());
    }

    private void Fire()
    {
        var fireBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        fireBullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletVelocity, ForceMode.Impulse);
        
    }

    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        Debug.Log("Weapon Reloaded");
    }
}
