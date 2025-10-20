using UnityEngine;
using UnityEngine.EventSystems;

public class PanelController : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    // close panel when click
    public void OnPointerClick(PointerEventData eventData)
    {
        HidePanel();
    }
}
