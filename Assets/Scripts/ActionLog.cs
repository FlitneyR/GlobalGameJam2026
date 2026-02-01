using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public struct LogMessage
{
    public string message;
    public Color colour;
}

public class ActionLog : MonoBehaviour
{
    public List<LogMessage> Messages { get; private set; } = new List<LogMessage>();

    private TextMeshProUGUI logText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logText = GetComponentInChildren<TextMeshProUGUI>();
        logText.text = "";
    }

    public void AddMessage(string message, Color colour)
    {
        AddMessage(new LogMessage { message = message, colour = colour });
    }

    public void AddMessage(LogMessage message)
    {
        Messages.Add(message);
        UpdateText();
    }

    private void UpdateText()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var logMessage in Messages)
        {
            string hexColour = ColorUtility.ToHtmlStringRGB(logMessage.colour);
            sb.AppendLine($"<color=#{hexColour}>{logMessage.message}</color>");
        }

        logText.text = sb.ToString();
        logText.ForceMeshUpdate();

        if (logText.isTextOverflowing)
        {
            Messages.RemoveAt(0);
            UpdateText();
        }
    }
}
