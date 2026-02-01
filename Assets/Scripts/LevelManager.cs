using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Level Data")]
public class LevelData : ScriptableObject
{
    public string scenePath;
    public string levelName;
}

[CreateAssetMenu(fileName = "LevelManager", menuName = "Scriptable Objects/Level Manager")]
public class LevelManager : ScriptableObject
{
    static LevelManager instance;

    public static LevelManager Get()
    {
        if (instance == null)
        {
            instance = Resources.Load<LevelManager>("LevelManager");
        }

        return instance;
    }

    public List<LevelData> levels;
    public string mainMenuPath;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuPath);
    }

    public void GoToNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Finished level: " + scene.name);

        int levelIndex = levels
            .FindIndex(level =>
                level.scenePath == scene.path
            );

        if (levelIndex < 0)
        {
            Debug.Log("Finished a level, but it isn't registered in the LevelManager");
            return;
        }

        if (levelIndex + 1 >= levels.Count)
        {
            Debug.Log("Reached the end of the levels");
            return;
        }

        SceneManager.LoadScene(levels[levelIndex + 1].scenePath);
    }
}
