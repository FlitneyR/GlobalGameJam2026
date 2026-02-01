using UnityEngine;

public class EndLevelScreen : MonoBehaviour
{
    public static EndLevelScreen instance;

    void Start()
    {
        if (instance == null)
            instance = this;

        victoryMessage.SetActive(false);
        failureMessage.SetActive(false);
    }

    ~EndLevelScreen()
    {
        if (instance == this)
            instance = null;
    }

    public GameObject victoryMessage;
    public GameObject failureMessage;

    public void ShowFailure()
    {
        failureMessage.SetActive(true);
    }

    public void ShowVictory()
    {
        victoryMessage.SetActive(true);
    }

    public void Restart()
    {
        LevelManager.Get().RestartLevel();
    }

    public void Continue()
    {
        LevelManager.Get().GoToNextLevel();
    }
}
