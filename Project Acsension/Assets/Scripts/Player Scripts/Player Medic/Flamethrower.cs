using UnityEngine;
using UnityEngine.InputSystem;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(flameHitDetection.position, flameHitDetection.transform.forward, Color.red);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed && Time.time >= nextTimetoFire)
        {
            if (canFire)
            {
                fireRate = context.ReadValue<float>();
                flameParticles.Play();
                UseFlamethrower();
                nextTimetoFire = Time.time + 1f / fireRate;
                fuel -= 1;
            }
        }
        else if(context.canceled)
        {
            flameParticles.Stop();
        }
    }

    private void UseFlamethrower()
    {
        if (canFire)
        {
            RaycastHit hit;
            if (Physics.Raycast(flameHitDetection.position, flameHitDetection.transform.forward, out hit, flamethrowerRange))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(flameHitDetection.position, flameHitDetection.transform.right * hit.distance, Color.red);

                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

                if(enemy != null)
                {
                    enemy.TakeDamage(1);
                }
            }
        }
    }
}
