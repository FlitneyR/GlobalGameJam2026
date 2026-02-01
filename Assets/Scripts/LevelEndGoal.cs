using UnityEngine;
using System.Collections.Generic;

public class LevelEndGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() == null)
        {
            return;
        }

        LevelManager.Get().MarkLevelFinished();
        EndLevelScreen.instance.ShowVictory();
    }
}
