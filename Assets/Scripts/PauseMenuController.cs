using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    InputAction pauseAction;
    Canvas canvas;
    bool isPaused;

    void Start()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        canvas = GetComponentInChildren<Canvas>();

        Resume();
    }

    void Update()
    {
        if (pauseAction.triggered)
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isPaused = true;
        canvas.enabled = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        isPaused = false;
        canvas.enabled = false;
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        LevelManager.Get().RestartLevel();
    }

    public void ReturnToMainMenu()
    {
        LevelManager.Get().GoToMainMenu();
    }
}
