using UnityEngine;
using UnityEngine.InputSystem;

public class P : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    private Animator anim;
    private Vector2 moveInput;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Keyboard.current.aKey.isPressed ? -1f :
                      Keyboard.current.dKey.isPressed ? 1f : 0f;
        moveInput.y = Keyboard.current.sKey.isPressed ? -1f :
                      Keyboard.current.wKey.isPressed ? 1f : 0f;
    }

    void FixedUpdate()
    {
        // 카메라 기준 이동 방향
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f; camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = (camForward * moveInput.y + camRight * moveInput.x);
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();

        // Transform 이동
        transform.position += moveDir * moveSpeed * Time.fixedDeltaTime;

        // 회전
        if (moveDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.fixedDeltaTime * 10f);
        }

        // 애니메이션
        if (anim != null)
        {
            anim.SetBool("isWalking", moveDir.sqrMagnitude > 0.001f);
        }
    }
}
