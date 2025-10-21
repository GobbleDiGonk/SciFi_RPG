using UnityEngine;
using TMPro;

public class QuestPrompt : MonoBehaviour
{
    [SerializeField] TMP_Text label;  // 비워두면 자동으로 자기 것 찾음

    [TextArea]
    [SerializeField] string idleText  = "Press F";
    [TextArea]
    [SerializeField] string activeText = "Quest Start: Reach the end of the map";
    [TextArea]
    [SerializeField] string doneText   = "Quest Completed!";

    bool lastActive = false;
    bool lastDone   = false;

    void Awake()
    {
        if (!label) label = GetComponent<TMP_Text>();
    }

    void Start()
    {
        Set(idleText);
    }

    void Update()
    {
        
        if (NPCTrigger.questDone && !lastDone)
        {
            lastDone = true;
            Set(doneText);
            return;
        }

        
        if (NPCTrigger.questActive && !lastActive)
        {
            lastActive = true;
            Set(activeText);
        }
    }

    void Set(string t)
    {
        if (label) label.text = t;
    }
}
