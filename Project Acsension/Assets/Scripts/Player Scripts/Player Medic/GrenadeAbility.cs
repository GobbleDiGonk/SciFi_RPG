using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class Grenade : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform grenadeOutput;

    public float grenadeCooldown;
    public float grenadeVelocity;

    public bool canThrow;
    public bool isThrowing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canThrow = true;
    }

    public void Ability(InputAction.CallbackContext context)
    {
       if(context.performed)
        {
            StartCoroutine(grenadeAbility());
        }
    }

    public IEnumerator grenadeAbility()
    {
        canThrow = false;
        isThrowing = true;
        var throwGrenade = Instantiate(grenadePrefab, grenadeOutput.forward, grenadeOutput.rotation);
        throwGrenade.GetComponent<Rigidbody>().AddForce(grenadeOutput.forward * grenadeVelocity, ForceMode.Impulse);
        yield return new WaitForSeconds(grenadeCooldown);
        isThrowing = false;
        canThrow = true;
    }
}
