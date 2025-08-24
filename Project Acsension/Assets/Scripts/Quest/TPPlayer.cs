
using UnityEngine;
using UnityEngine.InputSystem; 

[RequireComponent(typeof(Rigidbody))]
public class TPPlayer_NoAsset : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;

    Rigidbody rb;
    float inputX;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    void Update()
    {
        
        var kb = Keyboard.current;
        if (kb == null) return; 

        inputX = 0f;
        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  inputX -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) inputX += 1f;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(inputX * moveSpeed, rb.linearVelocity.y, 0f);
    }
}
