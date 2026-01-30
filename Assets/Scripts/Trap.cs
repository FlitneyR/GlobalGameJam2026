using UnityEngine;

public class Trap : MonoBehaviour
{
    public DamageParams.Type damageType;

    void OnTriggerEnter2D(Collider2D collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver)
        {
            DamageParams damageParams = new DamageParams();
            damageParams.type = damageType;

            damageReceiver.TakeDamage(damageParams);
        }
    }
}
