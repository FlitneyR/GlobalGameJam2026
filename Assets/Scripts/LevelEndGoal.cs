using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelEndGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() == null)
        {
            return;
        }

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Finished level: " + scene.name);

        LevelManager levelManager = LevelManager.Get();
        List<LevelData> levels = levelManager.levels;

        int levelIndex = levels
            .FindIndex(level =>
                level.scenePath == scene.path
            );

        if (levelIndex < 0)
        {
            Debug.Log("Finished a level, but it isn't registered in the LevelManager");
            return;
        }

        if (levelIndex + 1 >= LevelManager.Get().levels.Count)
        {
            Debug.Log("Reached the end of the levels");
            return;
        }

        SceneManager.LoadScene(LevelManager.Get().levels[levelIndex + 1].scenePath);
    }
}
