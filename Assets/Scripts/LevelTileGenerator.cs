using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTileGenerator : MonoBehaviour
{
    [SerializeField] private Transform levePanel;
    [SerializeField] private GameObject levelItemPrefab;
    void Start()
    {
        int levelCounter = SceneManager.sceneCountInBuildSettings;
        for (int i = 1; i < levelCounter; i++)
        {
            GameObject tempOBJ = Instantiate(levelItemPrefab, levePanel);
            tempOBJ.GetComponent<ItemController>().SetLevel(i);
        }
    }
}
