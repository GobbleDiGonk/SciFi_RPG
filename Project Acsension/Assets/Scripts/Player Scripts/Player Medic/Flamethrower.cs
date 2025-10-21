using UnityEngine;

using System.Collections.Generic;
using System.Collections;

public class Flamethrower : MonoBehaviour
{
    [Header("Flamethrower Stuff")]
    public Transform flameHitDetection;
    public ParticleSystem flameParticles;
    [SerializeField] float flamethrowerRange = 150f;
    [SerializeField] float fireRate = 20f;
    [SerializeField] float nextTimetoFire = 0f;
    [SerializeField] float fuel = 100;

    public bool canFire;
    public bool canRegenAmmo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(flameHitDetection.position, flameHitDetection.transform.forward, Color.red);

        if (Input.GetButton("Fire1") && canFire)
        {
            flameParticles.Play();
            UseFlamethrower();
            nextTimetoFire = Time.time + 1f / fireRate;
        }
        else
        {
            flameParticles.Stop();
        }

        if(fuel <= 0)
        {
            canFire = false;
            canRegenAmmo = true;
            AmmoRegen();
        }
        else if(fuel >= 100)
        {
            canFire = true;
            canRegenAmmo=false;
            AmmoRegen();
        }
        else if (fuel < 100)
        {
            canRegenAmmo = true;
            AmmoRegen();
        }
    }

    private void UseFlamethrower()
    {
        if (canFire)
        {
            RaycastHit hit;
            if (Physics.Raycast(flameHitDetection.position, flameHitDetection.transform.forward * flamethrowerRange, out hit))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(flameHitDetection.position, flameHitDetection.transform.forward * flamethrowerRange, Color.red);

                var enemyHealth = GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1);
                }
            }
            fuel -= 1;
        }
    }

    private void AmmoRegen()
    {
        if(canRegenAmmo)
        {
            fuel += 1 * Time.deltaTime;
            Debug.Log("Is regenerating ammo");
        }
    }
}
