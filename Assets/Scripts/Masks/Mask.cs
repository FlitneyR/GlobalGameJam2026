using System.Linq;
using UnityEngine;

public class Mask : MonoBehaviour
{
    /// <summary>
    /// Filter/react to damage
    /// </summary>
    /// <param name="damage"></param>
    /// <returns> true if the damage passes through, false if it is blocked </returns>
    public virtual bool OnDamage(DamageParams damage)
    {
        return true;
    }

    /// <summary>
    /// Check if you can interact with an interactable
    /// </summary>
    /// <param name="interactableObject"></param>
    /// <returns> true if you can interact with the interactable </returns> 
    public virtual bool CanInteract(Interactable interactableObject)
    {
        return false;
    }

    public virtual void OnCollect()
    {
        GetComponents<LogEvent>().First(le => le.id == "OnCollect")?.LogMessage();
    }

    public virtual void OnUse()
    {
        GetComponents<LogEvent>().First(le => le.id == "OnUse")?.LogMessage();
    }
}
