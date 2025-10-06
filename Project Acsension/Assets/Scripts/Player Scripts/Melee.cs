using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;

public class Melee : MonoBehaviour
{
    public Transform meleeHitbox;
    public GameObject meleeWeapon;
    Animator playerAnimator;

    [Header("Melee Stats")]
    public float meleeDamage = 2f;
    public float meleeSpeed = 1f;
    public float meleeCooldown = 1;
    public float meleeRange;

    public bool canMelee;
    public bool isSwinging;

    public LayerMask EnemyLayer;

    private void Start()
    {
        canMelee = true;
        playerAnimator.GetComponent<Animator>();
        meleeWeapon.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void MeleeAttack(InputAction.CallbackContext context)
    {
        Swing();
    }

    private void Swing()
    {
        Collider[] hitbox = Physics.OverlapSphere(meleeHitbox.position, meleeRange, EnemyLayer);

        foreach (Collider enemyGameObject in hitbox )
        {
            Debug.Log("Enemy hit");
            GetComponent<EnemyHealth>();
        }

        playerAnimator.Play("meleeSwing");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleeHitbox.transform.position, meleeRange);
    }




}
