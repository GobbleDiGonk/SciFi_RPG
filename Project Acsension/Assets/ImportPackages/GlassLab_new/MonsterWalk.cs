using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterWalk : MonoBehaviour
{
    [Header("왕복 이동 설정")]
    public float moveDuration = 3f;       // 한 방향으로 걷는 시간
    public float turnDuration = 0.5f;     // 방향 전환에 걸리는 시간

    private float timer = 0f;
    private bool movingRight = true;
    private bool isTurning = false;
    private float turnTimer = 0f;
    private Quaternion targetRotation;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;
        animator.SetBool("isWalking", true);
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (!isTurning)
        {
            timer += Time.deltaTime;
            if (timer >= moveDuration)
            {
                timer = 0f;
                movingRight = !movingRight;
                isTurning = true;

                // 180도 회전 목표 설정
                targetRotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
                turnTimer = 0f;
            }
        }
        else
        {
            // 회전 중일 때
            turnTimer += Time.deltaTime;
            float t = Mathf.Clamp01(turnTimer / turnDuration);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);

            if (t >= 1f)
            {
                isTurning = false; // 회전 완료
            }
        }
    }
}
