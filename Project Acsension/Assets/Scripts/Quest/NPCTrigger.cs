using UnityEngine;
using UnityEngine.InputSystem;

public class NPCTrigger : MonoBehaviour
{
    public static bool questActive = false;
    public static bool questDone = false;

    bool inRange = false;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("[NPC] Player entered. Press Space to accept quest.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("[NPC] Player left.");
        }
    }

    void Update()
    {
       
        bool spaceOld = Input.GetKeyDown(KeyCode.Space); // Old Input (When "both")
        bool spaceNew = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame; // New Input

        if (inRange && !questActive && !questDone && (spaceOld || spaceNew))
        {
            questActive = true;
            Debug.Log("[NPC] Quest Start! (questActive = true)");
        }
    }
}
