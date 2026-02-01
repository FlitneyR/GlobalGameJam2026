using UnityEngine;

public class LogEvent : MonoBehaviour
{
    public string id;
    public string message;
    public Color colour;

    private GameObject player;
    private ActionLog actionLog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        actionLog = player.GetComponentInChildren<ActionLog>();
     
        if (!actionLog)
            Debug.LogError("ActionLog component not found on Player.");
    }

    public void LogMessage()
    {
        actionLog.AddMessage(message, colour);
    }
}
