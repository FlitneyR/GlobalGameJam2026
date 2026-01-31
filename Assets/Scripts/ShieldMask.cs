using UnityEngine;

public class ShieldMask : Mask
{
    public DamageParams.Type type;

    public override bool OnDamage(DamageParams damage)
    {
        return damage.type != type;
    }
}
