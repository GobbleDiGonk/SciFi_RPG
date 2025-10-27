using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterTurnWalk : MonoBehaviour
{
    [Header("왕복 이동 설정")]
    public float moveDuration = 3f;       
    public float turnDuration = 0.5f;     

    private float timer;
    private bool isTurning = false;
    private float turnTimer = 0f;
    private Quaternion startRot;
    private Quaternion targetRot;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;

        // 랜덤 시작 타이머로 여러 마리가 동시에 움직이지 않도록
        timer = Random.value * moveDuration;

        startRot = transform.rotation;
        targetRot = transform.rotation;
    }

    void Update()
    {
        if (!isTurning)
        {
            timer += Time.deltaTime;

            if (timer >= moveDuration)
            {
                timer = 0f;
                isTurning = true;
                turnTimer = 0f;

                startRot = transform.rotation;
                targetRot = transform.rotation * Quaternion.Euler(0f, 180f, 0f);
            }
        }
        else
        {
            turnTimer += Time.deltaTime;
            float t = Mathf.Clamp01(turnTimer / turnDuration);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);

            if (t >= 1f)
                isTurning = false;
        }
    }
}
