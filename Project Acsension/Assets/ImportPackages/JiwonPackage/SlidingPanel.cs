using UnityEngine;
using UnityEngine.EventSystems;

public class SlidingPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Panel Settings")]
    public RectTransform panel;      // 실제 슬라이드될 패널
    public Vector2 closedPos;        // 숨길 위치 (화면 밖)
    public Vector2 openPos;          // 열린 위치
    public float speed = 5f;         // 슬라이드 속도

    [Header("Quest Text")]
    public GameObject questText;     // 패널 안 텍스트

    private bool isOpen = false;
    private bool pointerInside = false;

    void Update()
    {
        if (panel == null) return;

        // 패널 위치 슬라이드
        panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, isOpen ? openPos : closedPos, Time.deltaTime * speed);

        // Lerp 오차 때문에 distance 체크 제거
        if (questText != null)
        {
            // 패널 열려 있고, 퀘스트 활성화되어 있으면 텍스트 켜기
            questText.SetActive(isOpen && NPCTrigger.questActive);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
        pointerInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
        pointerInside = false;
    }
}
