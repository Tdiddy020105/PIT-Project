using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerr : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        // Set playerInRange to false and deactivate the visual cue game object on Awake
        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update() 
    {
        // Check if the player is in range and if no dialogue is currently playing
        if (playerInRange && !DialogueManagerr.GetInstance().dialogueIsPlaying)
        {
            // Activate the visual cue game object
            visualCue.SetActive(true);

            // Check if the player pressed the E key
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Trigger entering dialogue mode using the Ink JSON
                DialogueManagerr.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            // Deactivate the visual cue game object
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider has the "Player" tag
        if (collider.gameObject.tag == "Player")
        {
            // Set playerInRange to true when the player enters the trigger zone
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // Check if the collider has the "Player" tag
        if (collider.gameObject.tag == "Player")
        {
            // Set playerInRange to false when the player exits the trigger zone
            playerInRange = false;
        }
    }
}