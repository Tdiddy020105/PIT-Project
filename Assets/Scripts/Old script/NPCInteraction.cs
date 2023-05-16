using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NPCInteraction : MonoBehaviour
{
    public string dialogue;

    public GameObject dialogueBox;
    private DialogueDisplay dialogueDisplay;

    public float interactDistance = 2f;
    private bool canInteract = false;

    public string sceneName;

    void Start()
    {
        dialogueBox.SetActive(false);
        dialogueDisplay = dialogueBox.GetComponentInChildren<DialogueDisplay>();
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interacted");
            dialogueBox.SetActive(true);
            dialogueDisplay.DisplayDialogue(dialogue);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("StoppedInteraction");
            dialogueBox.SetActive(false);
        }
    }
*/
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            //dialogueBox.SetActive(true);
            //dialogueDisplay.DisplayDialogue(dialogue);
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            dialogueBox.SetActive(false);
        }
}

}

