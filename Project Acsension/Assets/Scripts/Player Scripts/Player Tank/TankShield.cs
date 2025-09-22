using UnityEngine;
using UnityEngine.InputSystem;

public class TankShield : MonoBehaviour
{
    public GameObject tankShield;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tankShield.SetActive(false);
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
        
    }
}
