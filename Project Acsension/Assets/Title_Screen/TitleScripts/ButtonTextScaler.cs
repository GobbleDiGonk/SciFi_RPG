using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverFull : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;
    public GameObject triangle;       // triangle cursor
    public float hoverScale = 1.2f;
    public Color hoverColor = Color.yellow;
    public float rotationSpeed = 100f; 

    private Vector3 originalScale;
    private Color originalColor;
    private bool isHover = false;

    void Start()
    {
        originalScale = buttonText.transform.localScale;
        originalColor = buttonText.color;
        triangle.SetActive(false);
    }

    void Update() // cursor rotation
    {
        if (isHover)
        {
            triangle.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // Scale
    {
        isHover = true;
        buttonText.transform.localScale = originalScale * hoverScale;
        buttonText.color = hoverColor;
        triangle.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) // Colour Change
    {
        isHover = false;
        buttonText.transform.localScale = originalScale;
        buttonText.color = originalColor;
        triangle.SetActive(false);
    }
}
