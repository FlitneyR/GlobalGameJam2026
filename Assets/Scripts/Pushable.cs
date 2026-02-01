using UnityEngine;

public class Pushable : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool canPush = false;

        MaskStack maskStack = collision.gameObject.GetComponent<MaskStack>();
        if (maskStack != null)
        {
            Mask topMask = maskStack.GetTopMask();
            if (topMask != null)
            {
                canPush = topMask.CanPush(this);
            }
        }

        if (canPush)
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        else
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
