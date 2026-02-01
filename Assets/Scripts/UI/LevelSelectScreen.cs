using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectScreen : MonoBehaviour
{
    public GameObject levelSelectButtonPrefab;

    void Start()
    {
        int index = 1;
        foreach (LevelData level in LevelManager.Get().levels)
        {
            GameObject buttonGameObject = Instantiate(levelSelectButtonPrefab);
            buttonGameObject.transform.SetParent(gameObject.transform);

            buttonGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + index + ": " + level.levelName;

            Button button = buttonGameObject.GetComponentInChildren<Button>();

            button.onClick.AddListener(delegate
            {
                LevelManager.Get().GoToLevel(level.scenePath);
            });

            button.interactable = LevelManager.Get().CanSelectLevel(level.scenePath);
            index += 1;
        }
    }
}
