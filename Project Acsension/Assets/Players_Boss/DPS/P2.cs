using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] // Rigidbody 대신 CharacterController 요구
[RequireComponent(typeof(Animator))]
public class P2_CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float gravity = -9.81f; // 중력 가속도 (유니티 기본값)
    private float verticalVelocity; // 수직 속도 (중력, 점프 처리용)

    private CharacterController controller;
    private Animator anim;
    private Vector2 moveInput;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // cameraTransform 자동 할당
        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // 1. 입력 처리
        moveInput.x = Keyboard.current.aKey.isPressed ? -1f :
                      Keyboard.current.dKey.isPressed ? 1f : 0f;
        moveInput.y = Keyboard.current.sKey.isPressed ? -1f :
                      Keyboard.current.wKey.isPressed ? 1f : 0f;

        // 2. 점프 입력 (CharacterController는 isGrounded 속성을 가집니다)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && controller.isGrounded)
        {
            // 점프 힘을 수직 속도에 할당
            verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            if (anim != null) anim.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        if (cameraTransform == null) return;

        // 1. 카메라 기준 이동 방향 계산
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f; camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * moveInput.y + camRight * moveInput.x;
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();

        // 2. 중력 및 수직 속도 적용
        if (controller.isGrounded)
        {
            // 땅에 닿아있을 때, 아주 작은 음수 값을 유지하여 확실히 바닥에 붙도록 함
            if (verticalVelocity < 0)
            {
                verticalVelocity = -2f;
            }
        }
        else
        {
            // 공중에 있을 때 중력 적용
            verticalVelocity += gravity * Time.fixedDeltaTime;
        }

        // 3. 최종 이동 벡터 계산
        // 수평 이동 속도 (moveDir)
        Vector3 horizontalMovement = moveDir * moveSpeed;

        // 수직 이동 속도 (점프 + 중력)
        Vector3 verticalMovement = new Vector3(0, verticalVelocity, 0);

        // CharacterController.Move()로 이동 및 충돌 처리
        // CharacterController는 물리 엔진을 우회하며, Move()를 통해야만 충돌을 감지하고 멈춥니다.
        controller.Move((horizontalMovement + verticalMovement) * Time.fixedDeltaTime);


        // 4. 회전
        if (moveDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            // Transform.rotation을 사용하여 회전합니다 (Rigidbody 없음)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.fixedDeltaTime * 10f);
        }

        // 5. 애니메이션
        if (anim != null)
        {
            anim.SetBool("isWalking", moveDir.sqrMagnitude > 0.001f);
        }
    }
}