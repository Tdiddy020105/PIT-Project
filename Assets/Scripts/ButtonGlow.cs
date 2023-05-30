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
        buttonImage = GetComponent<Image>();
        normalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = glowColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = normalColor;
    }
}

