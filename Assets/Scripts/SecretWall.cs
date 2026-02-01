using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : Interactable
{
    public List<GameObject> ObjectsToHide;
    public List<GameObject> ObjectsToReveal;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Type = InteractableType.SecretWall;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        MaskStack masks = collider.GetComponent<MaskStack>();
        Mask activeMask = masks ? masks.GetTopMask() : null;
        
        if (!activeMask)
            return;
         
        if (activeMask.CanInteract(this))
            RevealWall();
    }

    private void RevealWall()
    {
        Debug.Log("Secret wall revealed!");

        foreach (GameObject obj in ObjectsToHide)
            obj.SetActive(false);

        foreach (GameObject obj in ObjectsToReveal)
            obj.SetActive(true);
    }
}
