using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class Flamethrower : MonoBehaviour
{
    [Header("Flamethrower Stuff")]
    public Transform flameHitDetection;
    public GameObject flameParticles;
    public GameObject flameThrowerMuzzle;
    [SerializeField] float flamethrowerRange;
    [SerializeField] float fireRate = 20f;
    [SerializeField] float nextTimetoFire = 0f;
    public LayerMask Enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if(context.performed && Time.time >= nextTimetoFire)
        {
            flameThrowerMuzzle.SetActive(true);
            useFlamethrower();
            nextTimetoFire = Time.time + 1f / fireRate;
        }
    }

    private void useFlamethrower()
    {
        RaycastHit hit;
        if (Physics.Raycast(flameHitDetection.position, flameHitDetection.transform.right, out hit, flamethrowerRange, Enemy))
        {
            var enemyHealth = GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}
