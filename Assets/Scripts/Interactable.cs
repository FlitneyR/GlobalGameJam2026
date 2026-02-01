using UnityEngine;

public enum InteractableType
{
    None,
    Door,
    SecretWall,
}

public class Interactable : MonoBehaviour
{
    public InteractableType Type { get; set; } = InteractableType.None;
}
