using UnityEngine;

public class DoorMask : Mask
{
    public InteractableType interactableType;

    public override bool CanInteract(Interactable interactableObject)
    {
        bool canInteract = interactableType != InteractableType.None && interactableObject.Type == interactableType;
        if (canInteract) OnUse();
        return canInteract;
    }
}
