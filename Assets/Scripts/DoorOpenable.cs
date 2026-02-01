using System;
using UnityEngine;

public class DoorOpenable : Interactable
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        MaskStack masks = collision.collider.GetComponent<MaskStack>();
        Mask activeMask = masks ? masks.GetTopMask() : null;
        
        if (!activeMask)
            return;
         
        if (activeMask.CanInteract(this))
            OpenDoor();
    }

    private void OpenDoor()
    {
        Debug.Log("Door opened!");
        animator.SetTrigger("Open");
        rigidBody.simulated = false;
    }

    private void CloseDoor()
    {
        Debug.Log("Door closed!");
        animator.SetTrigger("Close");
        rigidBody.simulated = true;
    }
}
