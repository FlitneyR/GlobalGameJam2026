using System;
using UnityEngine;

public class DoorOpenable : Interactable
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        Type = InteractableType.Door;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    }

    private void CloseDoor()
    {
        Debug.Log("Door closed!");
        animator.SetTrigger("Close");
    }
}
