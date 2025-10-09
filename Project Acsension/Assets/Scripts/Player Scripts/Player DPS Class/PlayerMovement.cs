using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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

    private bool canRoll;
    private bool isRolling;

    [Header("Dashing Stuff")]
    public float rollPower = 24f;
    public float rollTime = 0.2f;
    public float rollCooldown = 5f;

    public Animator rollAnim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //gets the rigidbody component of the player
        rb.freezeRotation = true; //prevents the player from falling over
        direction = 1;
        canRoll = true;
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

    public void DodgeRoll(InputAction.CallbackContext context)
    {
        if(context.performed && canRoll)
        {
            StartCoroutine(Roll());
        }
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

    private IEnumerator Roll()
    {

        if (isGrounded())
        {
            canRoll = false;
            isRolling = true;
            bool originalGraivty = rb.useGravity;
            rb.useGravity = false;
            rb.linearVelocity = new Vector2(transform.localScale.x * rollPower, 0f);
            rollAnim.Play("DodgeRoll");
            Debug.Log("Is rolling baby");
            rb.useGravity = true;
            isRolling = false;
            yield return new WaitForSeconds(rollCooldown);
            canRoll = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isRolling)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        if(isRolling)
        {
            return;
        }

        Flip();

        rb.linearVelocity = new Vector2(horizontalMovement * movementSpeed, rb.linearVelocity.y);
    }
}
