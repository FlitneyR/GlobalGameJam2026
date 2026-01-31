using UnityEngine;
using System.Collections.Generic;

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
}
