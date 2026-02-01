using UnityEngine;

public class ShieldMask : Mask
{
    public DamageParams.Type type;

    public override bool OnDamage(DamageParams damage)
    {
        bool shouldTakeDamage = damage.type != type;
        if (!shouldTakeDamage) OnUse();
        return shouldTakeDamage;
    }
}
