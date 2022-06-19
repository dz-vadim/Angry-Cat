using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;

    public void ChangeWindow(int index)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == index)
            {
                windows[i].SetActive(true);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
