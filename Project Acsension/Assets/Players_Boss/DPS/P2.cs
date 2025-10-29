using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class P2 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    [Header("Jump Settings")]
    public float jumpForce = 5f;

    private Animator anim;
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        // cameraTransform 자동 할당
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        // Rigidbody Constraints
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ |
                         RigidbodyConstraints.FreezeRotationY; // Y 회전 자유
    }

    void Update()
    {
        // Keyboard 입력
        moveInput.x = Keyboard.current.aKey.isPressed ? -1f :
                      Keyboard.current.dKey.isPressed ? 1f : 0f;
        moveInput.y = Keyboard.current.sKey.isPressed ? -1f :
                      Keyboard.current.wKey.isPressed ? 1f : 0f;

        // 점프 입력
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            isGrounded = false;
            if (anim != null) anim.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        if (cameraTransform == null) return;

        // 카메라 기준 이동
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f; camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * moveInput.y + camRight * moveInput.x;
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();

        // Rigidbody MovePosition → X/Z만 이동
        Vector3 targetPos = rb.position + new Vector3(moveDir.x, 0f, moveDir.z) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPos);

        // 회전
        if (moveDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, Time.fixedDeltaTime * 10f));
        }

        // 애니메이션
        if (anim != null)
        {
            anim.SetBool("isWalking", moveDir.sqrMagnitude > 0.001f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ground 태그가 있는 바닥에서만 점프 재활성화
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
