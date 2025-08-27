
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
    // Get reference to the current keyboard (from Unity's Input System)
    var kb = Keyboard.current;
    if (kb == null) return;   // If no keyboard is connected, exit early

    inputX = 0f;  // Reset horizontal input every frame

    // If 'A' key or Left Arrow is pressed -> move left
    if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  
        inputX -= 1f;

    // If 'D' key or Right Arrow is pressed -> move right
    if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) 
        inputX += 1f;
}


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(inputX * moveSpeed, rb.linearVelocity.y, 0f);
    }
}
