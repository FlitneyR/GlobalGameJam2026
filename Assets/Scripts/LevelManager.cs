using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Level Data")]
public class LevelData : ScriptableObject
{
    public string scenePath;
    public string levelName;

    [System.NonSerialized]
    public bool hasFinished;
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
        GoToLevel(SceneManager.GetActiveScene().path);
    }

    public void GoToMainMenu()
    {
        GoToLevel(mainMenuPath);
    }

    int FindLevelIndex(string path)
    {
        return levels.FindIndex(level => level.scenePath == path);
    }

    public void GoToNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Finished level: " + scene.name);

        int levelIndex = FindLevelIndex(scene.path);

        if (levelIndex < 0)
        {
            Debug.Log("Finished a level, but it isn't registered in the LevelManager");
            return;
        }

        levels[levelIndex].hasFinished = true;

        if (levelIndex + 1 >= levels.Count)
        {
            Debug.Log("Reached the end of the levels");
            return;
        }

        GoToLevel(levels[levelIndex + 1].scenePath);
    }

    public void GoToLevel(string levelPath)
    {
        SceneManager.LoadScene(levelPath);
    }

    public bool CanSelectLevel(string levelPath)
    {
        int levelIndex = FindLevelIndex(levelPath);

        if (levelIndex < 0)
        {
            Debug.Log(levelPath + " is not a registered level");
            return false;
        }

        return levelIndex == 0 || levels[levelIndex - 1].hasFinished;
    }
}
