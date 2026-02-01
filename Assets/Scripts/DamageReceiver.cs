using System;
using System.Linq;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public AudioClip damageSound;
    public AudioClip deathSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(DamageParams damage)
    {
        MaskStack maskStack = GetComponent<MaskStack>();
        if (maskStack != null)
        {
            Mask topMask = maskStack.GetTopMask();
            if (topMask != null)
            {
                // if the top mask blocks damage, do nothing
                if (!topMask.OnDamage(damage))
                {
                    Debug.Log("Blocked " + damage.type + " damage");
                    return;
                }

                // otherwise, remove the top mask, but don't kill the player
                maskStack.RemoveMask();

                if (audioSource != null)
                {
                    audioSource.PlayOneShot(damageSound);
                }

                LogDamageEvent(damage);

                return;
            }
        }

        // nothing left to save you, you die
        Debug.Log("Took " + damage.type + " damage");

        if (audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        Destroy(GetComponent<Player>());
        Destroy(GetComponentInChildren<SpriteRenderer>());

        EndLevelScreen.instance.ShowFailure();
    }

    private void LogDamageEvent(DamageParams damage)
    {
        string logId = "OnTakeDamage" + damage.type.ToString();
        GetComponents<LogEvent>().First(le => le.id == logId)?.LogMessage();
    }
}
