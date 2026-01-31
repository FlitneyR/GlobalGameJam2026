using UnityEngine;
using System.Collections.Generic;

public class MaskStack : MonoBehaviour
{
    Stack<Mask> masks;

    public float maskOffset = 1.0f;

    void Start()
    {
        masks = new Stack<Mask>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Mask mask = collider.GetComponent<Mask>();
        if (mask != null)
        {
            Debug.Log("Collected mask: " + mask);

            // remove the masks's rigidbody
            Destroy(collider.GetComponent<Rigidbody2D>());

            // attach the mask to the player
            mask.gameObject.transform.SetParent(gameObject.transform);
            mask.gameObject.transform.localPosition = new Vector2(0, maskOffset * masks.Count);

            // make masks render in front of the player, and lower masks
            SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = "Masks";
                spriteRenderer.sortingOrder = masks.Count;
            }

            masks.Push(mask);
        }
    }

    public void RemoveMask()
    {
        if (masks.Count == 0)
        {
            return;
        }

        Destroy(masks.Pop().gameObject);
    }

    public Mask GetTopMask()
    {
        if (masks.Count == 0)
        {
            return null;
        }

        return masks.Peek();
    }
}
