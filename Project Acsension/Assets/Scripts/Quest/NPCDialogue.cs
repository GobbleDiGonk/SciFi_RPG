using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] GameObject dialoguePanel;   // 대사 패널
    [SerializeField] GameObject namePanel;       // 이름 패널

    [Header("UI Texts")]
    [SerializeField] TMP_Text dialogueText;      // 대사 텍스트
    [SerializeField] TMP_Text nameText;          // 이름 텍스트

    [Header("Dialogue Settings")]
    [SerializeField] string npcName;             // NPC 이름
    [TextArea(2,2)]
    [SerializeField] string[] dialogues;         // 대사 배열

    int currentIndex = 0;

    void Start()
    {
        // 처음에는 두 패널 모두 비활성화
        if (dialoguePanel) dialoguePanel.SetActive(false);
        if (namePanel) namePanel.SetActive(false);
    }

    public void StartDialogue()
    {
        if (dialogues.Length == 0) return;

        currentIndex = 0;

        if (dialoguePanel) dialoguePanel.SetActive(true);
        if (namePanel) namePanel.SetActive(true);

        UpdateUI();
    }

    public void NextDialogue()
    {
        currentIndex++;
        if (currentIndex < dialogues.Length)
        {
            UpdateUI();
        }
        else
        {
            EndDialogue();
        }
    }

    void UpdateUI()
    {
        if (nameText) nameText.text = npcName;

        if (dialogueText)
        {
            string text = dialogues[currentIndex];
            string[] lines = text.Split('\n');
            dialogueText.text = string.Join("\n", lines.Length > 2 ? lines[..2] : lines);
        }
    }

    void EndDialogue()
    {
        if (dialoguePanel) dialoguePanel.SetActive(false);
        if (namePanel) namePanel.SetActive(false);
    }
}
