using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Text levelIndexText;
    [SerializeField] private Text levelStartsText;
    [SerializeField] private Button startLevelButton;

    public void SetLevel(int levelIndex)
    {
        int stars = PlayerPrefs.GetInt($"Level{levelIndex}");
        levelIndexText.text = $"Level: {levelIndex}";
        levelStartsText.text = stars.ToString();
        if (levelIndex > 1)
        {
            int privStars = PlayerPrefs.GetInt($"Level{levelIndex - 1}");
            if (privStars == 0)
            {
                startLevelButton.interactable = false;
                startLevelButton.GetComponentInChildren<Text>().text = "Close";
            }
        }
        startLevelButton.onClick.AddListener(() => LoadLevel(levelIndex));
    }
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
