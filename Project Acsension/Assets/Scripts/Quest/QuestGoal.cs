using UnityEngine;

[RequireComponent(typeof(Collider))]
public class QuestGoal : MonoBehaviour
{
    [SerializeField] Renderer targetRenderer;

    void Reset()
    {
        var c = GetComponent<Collider>();
        if (c) c.isTrigger = true;
    }

    void Start()
    {
        if (targetRenderer) targetRenderer.material.color = Color.red;
        Debug.Log("[Goal] Ready");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[Goal] TriggerEnter with: {other.name}");

        if (!other.CompareTag("Player"))
        {
            Debug.Log("[Goal] Not player");
            return;
        }

        Debug.Log($"[Goal] Flags before -> active:{NPCTrigger.questActive}, done:{NPCTrigger.questDone}");
        if (!NPCTrigger.questActive || NPCTrigger.questDone)
        {
            Debug.Log("[Goal] Quest not active or already done. No effect.");
            return;
        }

        NPCTrigger.questActive = false;
        NPCTrigger.questDone = true;

        if (targetRenderer) targetRenderer.material.color = Color.blue;
        Debug.Log("[Goal] Quest Completed! Colour changed to blue.");
    }
}
