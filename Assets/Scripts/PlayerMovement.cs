using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;

    private DialogueManagerr dialogueManager;
    private bool isDialogueActive;

    Vector2 movement;

    private void Start()
    {
        dialogueManager = DialogueManagerr.GetInstance();
    }

    private void Update()
    {
        isDialogueActive = dialogueManager.dialogueIsPlaying;

        if (isDialogueActive)
        {
            return;
        }

        // Read input for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Set animator parameters for animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Set animator parameters for last move direction
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }

        // Set movement vector based on dominant axis
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }
    }

    private void FixedUpdate()
    {
        // Move the player if dialogue is not active
        if (!isDialogueActive)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
