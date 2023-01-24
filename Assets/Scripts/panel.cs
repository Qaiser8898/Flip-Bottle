using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    public GameObject HomePanel;
    public GameObject Button;
    public GameObject LevelPanel;
    // Start is called before the first frame update
    void Start()
    {
        HomePanel.SetActive(true);
        LevelPanel.SetActive(false);
        Debug.Log("Start function call");
    }
    void Update()
    {
        
    }
    public void LoadPanel()
    {
        Debug.Log("load function call");
        Button.SetActive(false);
        LevelPanel.SetActive(true);
        HomePanel.SetActive(false);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
