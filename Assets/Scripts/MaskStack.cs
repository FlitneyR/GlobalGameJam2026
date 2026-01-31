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
            masks.Push(mask);
            Debug.Log("Collected mask: " + mask);

            mask.gameObject.transform.SetParent(gameObject.transform);
            mask.gameObject.transform.localPosition = new Vector2(0, maskOffset * masks.Count);
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
