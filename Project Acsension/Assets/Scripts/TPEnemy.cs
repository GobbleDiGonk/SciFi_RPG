using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TPEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float patrolTime = 2f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] Transform target;


    Rigidbody rb;
    int direction = 1;
    float patrolTimer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent tipping over
    }

    void FixedUpdate()
    {
        if (target == null) return; //No action till target assigned

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        // Compute distance to player to decide patrol vs chase

        if (distanceToPlayer <= chaseRange)
        {
            //Chase mode
            float diff = target.position.x - transform.position.x;
            // Horizontal difference to player (positive = player on the right)

            float dir = 0f;
            // Deadzone to avoid jittering when overlapping or extremely close

            if (Mathf.Abs(diff) > 0.2f)  // When the distance is more than 0.2f
                dir = Mathf.Sign(diff); // 1 right, -1 left direction

            rb.linearVelocity = new Vector3(dir * moveSpeed, rb.linearVelocity.y, 0f);
            // Apply horizontal velocity, keep current vertical & z velocity

            Flip(dir);
        }
        else
        {
            //Patrol mode
            patrolTimer += Time.fixedDeltaTime; // Count time walking in current direction

            if (patrolTimer >= patrolTime)  // When timer expires, flip patrol direction and reset timer
            {
                direction *= -1;
                patrolTimer = 0f;
            }

            rb.linearVelocity = new Vector3(direction * moveSpeed, rb.linearVelocity.y, 0f);
            // Move horizontally in the current patrol direction; preserve y & z velocity

            Flip(direction);
        }
    }

    private void Flip(float dir)
    {
        // Update facing sign only when direction is clearly left/right (avoid tiny noise)
        if (dir > 0f) direction = 1;
        else if (dir < 0f) direction = -1;

        // Preserve original scale magnitude and only flip X sign
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }
}
