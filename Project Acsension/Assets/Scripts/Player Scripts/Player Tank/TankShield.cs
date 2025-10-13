using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class TankShield : MonoBehaviour
{
    public GameObject tankShield;

    public float currentShieldHealth;
    public float maxShieldHealth;
    public float shieldCooldownTime = 10;
    public float gracePeriod = 2;

    public bool canUseShield;
    public bool canTakeDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tankShield.SetActive(false);
        canUseShield = true;
        canTakeDamage = true;
    }

    public void deployShield(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            tankShield.SetActive(true);
        }
        else if (context.canceled)
        {
            tankShield.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShieldHealth == 0)
        {
            StartCoroutine(ShieldCooldown());
        }
    }

    public void ShieldDamage(int damage)
    {
        currentShieldHealth -= damage;

        if(currentShieldHealth == 0)
        {
            tankShield.SetActive(false);
        }
    }

    private IEnumerator ShieldCooldown()
    {
        canUseShield = false;
        yield return new WaitForSeconds(shieldCooldownTime);
        canUseShield = false;
    }

    private IEnumerator invincibilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(gracePeriod);
        canTakeDamage = true;
    }
}
