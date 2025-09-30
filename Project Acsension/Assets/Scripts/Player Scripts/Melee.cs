using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;

public class Melee : MonoBehaviour
{
    public GameObject meleeWeapon;

    [Header("Melee Stats")]
    public float meleeDamage;
    public float meleeSpeed;
    public float meleeCooldown;

    public bool canMelee;
    public bool isSwinging;

    private void Start()
    {
        meleeWeapon.SetActive(false);
    }

    private void Update()
    {
        if(isSwinging)
        {
            return;
        }
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        StartCoroutine(performMelee());
    }

    private IEnumerator performMelee()
    {
        if(canMelee)
        {
            canMelee = false;
            isSwinging = true;
            meleeHitbox.SetActive(true);
            Debug.Log("Is using melee");
            yield return new WaitForSeconds(meleeSpeed);
            isSwinging = false;
            yield return new WaitForSeconds(meleeCooldown);
            canMelee = true;
        }
    }
}
