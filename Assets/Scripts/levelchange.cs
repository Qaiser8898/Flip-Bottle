using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelchange : MonoBehaviour
{
    public GameObject ButtonLevel2;
    public GameObject WinText;
    void Start()
    {

        ButtonLevel2.SetActive(true);
    }

    void Update()
    {
        if (WinText.activeSelf ==true)
        {
            ButtonLevel2.SetActive(true);
        }
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
}
