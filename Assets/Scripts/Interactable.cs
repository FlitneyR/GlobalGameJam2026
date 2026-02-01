using UnityEngine;

public enum InteractableType
{
    NONE,
    DOOR,
    SECRET_WALL,
}

public class Interactable : MonoBehaviour
{
    public InteractableType Type { get; set; } = InteractableType.NONE;
}
