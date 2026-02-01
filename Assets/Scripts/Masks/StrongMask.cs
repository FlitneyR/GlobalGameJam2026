using UnityEngine;

public class StrongMask : Mask
{
    public override bool CanPush(Pushable pushable)
    {
        return true;
    }
}
