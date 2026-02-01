using UnityEngine;

public class DoorAnimEventHelper : MonoBehaviour
{
    public void OnDoorOpened()
    {
        Rigidbody2D rigidbody = GetComponentInParent<Rigidbody2D>();
        if (rigidbody)
        {
            rigidbody.simulated = false;
        }
    }

    public void OnDoorClosed()
    {
        Rigidbody2D rigidbody = GetComponentInParent<Rigidbody2D>();
        if (rigidbody)
        {
            rigidbody.simulated = true;
        }
    }
}
