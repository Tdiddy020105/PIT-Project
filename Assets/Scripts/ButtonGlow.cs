using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonGlow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    private Color normalColor;
    public Color glowColor;

    private void Start()
    {
        // Get the Image component attached to the button
        buttonImage = GetComponent<Image>();
        // Store the normal color of the button
        normalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Change the button color to the glow color when the pointer enters
        buttonImage.color = glowColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert the button color to the normal color when the pointer exits
        buttonImage.color = normalColor;
    }
}
