using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector2 velocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("We are supposed to jump");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
