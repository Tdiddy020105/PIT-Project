using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    private float displayDuration = 2f; // Duration in seconds to display the notification
    private float fadeDuration = 0.5f; // Duration in seconds for the fade-in and fade-out animations
    
    [Header("Notification UI")]

    [SerializeField] public TextMeshProUGUI notificationText;

    private void Start()
    {
        // Start the fade-out animation after the display duration has passed
        Invoke("FadeOut", displayDuration);
    }

    private void FadeOut()
    {
        // Trigger the fade-out animation using a coroutine
        StartCoroutine(FadeOutAnimation());
    }

    private IEnumerator FadeOutAnimation()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        // Gradually decrease the alpha value over the fade duration
        float timer = fadeDuration;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            canvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        // Disable the notification object once it's faded out
        gameObject.SetActive(false);
    }
}
