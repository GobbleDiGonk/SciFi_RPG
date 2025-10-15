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
            Debug.Log("[NPC] Player entered. Press F to accept quest.");
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
        bool fOld = Input.GetKeyDown(KeyCode.F);
        bool fNew = Keyboard.current?.fKey.wasPressedThisFrame ?? false;

        if (inRange && !questActive && !questDone && (fOld || fNew))
        {
            questActive = true;
            Debug.Log("[NPC] Quest Start! (questActive = true)");
        }
    }
}
