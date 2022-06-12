using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    [SerializeField] private int loadStars;
    [SerializeField] private float timeToThreeStars;
    [SerializeField] private float timeCoefficient;
    
    [SerializeField] private Text gameStopwatchText;
    [SerializeField] private Text allTimeText;
    [SerializeField] private Text starText;
    
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject gameInterface;
    [SerializeField] private GameObject[] interfaceButtons;
    
    private float _currentLevelTime;

    private void Tick()
    {
        _currentLevelTime += 0.1f;
        gameStopwatchText.text = string.Format("{0:N1} s", _currentLevelTime);
    }

    public void StartStopwatch()
    {
     InvokeRepeating(nameof(Tick), 0f,0.1f);   
    }

    public void StopStopwatch()
    {
        CancelInvoke();
    }

    public void LoadResult()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        loadStars = PlayerPrefs.GetInt($"Level{levelIndex}");
    }

    public void SaveResult()
    {
        //рахуємо кількість зароблених зірок
        int stars = 0;
        if (_currentLevelTime <= timeToThreeStars)
        {
            stars = 3;
        }
        else if (_currentLevelTime > timeToThreeStars && _currentLevelTime < timeToThreeStars * timeCoefficient)
        {
            stars = 2;
        }
        else
        {
            stars = 1;
        }
        //включаємо панель результаів, вмключаємо ігрову панель
        resultPanel.SetActive(true);
        gameInterface.SetActive(false);
        //виводимо результати в панель
        allTimeText.text = string.Format("Time: {0:N1}", _currentLevelTime);
        if (stars > loadStars)
        {
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt($"Level{levelIndex}", levelIndex);
            starText.text = $"Stars: {stars}";
            interfaceButtons[0].SetActive(false);
            interfaceButtons[1].SetActive(true);
        }
        else
        {
            starText.text = $"SLOW!";
            interfaceButtons[0].SetActive(true);
            interfaceButtons[1].SetActive(false);
        }
    }

    public void RestartLevel()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        int allLevels = SceneManager.sceneCountInBuildSettings;
        if (levelIndex < allLevels)
        {
            SceneManager.LoadScene(levelIndex + 1);
        }
    }
    
    void Start()
    {
        LoadResult();
        resultPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
