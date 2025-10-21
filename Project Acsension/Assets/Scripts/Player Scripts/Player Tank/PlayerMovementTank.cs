using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementTank : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    Rigidbody rb;

    float horizontalMovement;

    [Header("Ground Checker")]
    public Transform groundCheckPos;
    public float groundCheckSize;
    public LayerMask groundLayer;

    public int direction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //gets the rigidbody component of the player
        rb.freezeRotation = true; //prevents the player from falling over
        direction = 1; //Forces the player to face right upon spawning
    }

    public void Move(InputAction.CallbackContext context) //calls the movement input
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) //calls the jump input
    {
        if(isGrounded())
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

                rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            }
        }
    }

    public void ShieldUp(InputAction.CallbackContext context)
    {
        
    }

    private bool isGrounded() //uses raycast to check if the player is on the ground
    {
        if (Physics.Raycast(groundCheckPos.position, Vector3.down, groundCheckSize * 0.5f + 0.2f, groundLayer))
        {
            return true;
        }
        return false;
    }

    private void Flip() //checks the direction the player is moving to flip them
    {
        if(horizontalMovement > 0f)
        {
            direction = 1;
        }
        else if(horizontalMovement < 0f)
        {
            direction = -1;
        }

        transform.localScale = new Vector3(direction, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        Flip();

        rb.linearVelocity = new Vector2(horizontalMovement * movementSpeed, rb.linearVelocity.y);
    }
}
