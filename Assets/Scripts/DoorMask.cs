using UnityEngine;

public class DoorMask : Mask
{
    public InteractableType interactableType;

    public override bool CanInteract(Interactable interactableObject)
    {
        return interactableType != InteractableType.None && interactableObject.Type == interactableType;
    }
}
