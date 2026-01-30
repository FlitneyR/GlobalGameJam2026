
public class Mask
{
    /// <summary>
    /// Filter/react to damage
    /// </summary>
    /// <param name="damage"></param>
    /// <returns> true if the damage passes through, false if it is blocked </returns>
    public bool OnDamage(DamageParams damage)
    {
        return true;
    }
}
