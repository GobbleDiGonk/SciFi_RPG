using UnityEngine;
using UnityEngine.InputSystem;

public class NPCTrigger : MonoBehaviour
{
    public static bool questActive = false;
    public static bool questDone = false;

    bool inRange = false;

    [SerializeField] NPCDialogue dialogue; // Inspector에서 연결

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
            Debug.Log("[NPC] Player entered. Press F to talk.");
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

        if (inRange && fOld)
        {
            if (!questActive)
            {
                questActive = true;
                if (dialogue != null)
                    dialogue.StartDialogue();
            }
            else
            {
                if (dialogue != null)
                    dialogue.NextDialogue();
            }
        }
    }
}
