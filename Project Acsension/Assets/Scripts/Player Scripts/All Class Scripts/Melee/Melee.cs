using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;

public class Melee : MonoBehaviour
{
    public Transform meleeHitbox;
    public GameObject meleeWeapon;

    public Animator meleeAnimator;

    public WeaponColiision weaponCollision;

    [Header("Melee Stats")]
    public int meleeDamage = 5;
    public float meleeSpeed = 1f;
    public float meleeCooldown = 1;
    public float meleeRange;

    public bool canMelee;
    public bool isSwinging;

    public LayerMask EnemyLayer;

    private void Start()
    {
        canMelee = true;
        meleeWeapon.SetActive(false);
        weaponCollision.GetValues(this, meleeDamage);
    }

    private void Update()
    {
        
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        if (canMelee)
        {
            meleeWeapon.SetActive(true);
            meleeAnimator.Play("meleeSwing");
            canMelee = false;
        }
    }

    public void SwingEnd()
    {
        meleeWeapon.SetActive(false);
        canMelee = true;
    }



}
