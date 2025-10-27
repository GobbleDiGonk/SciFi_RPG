using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public Transform groundCheckPos;

    private Rigidbody rb;

    public float movementSpeed;
    public float groundCheckSize;

    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Mathf.Sign(target.position.x - transform.position.x);

        if(isGrounded())
        {
            rb.linearVelocity = new Vector2(direction * movementSpeed, rb.linearVelocity.y); //should chase player
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
}
