using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public void TakeDamage(DamageParams damage)
    {
        Debug.Log("Took " + damage.type + " damage");
        Destroy(gameObject);
    }
}
