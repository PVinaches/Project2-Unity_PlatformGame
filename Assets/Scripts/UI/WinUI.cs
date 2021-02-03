using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Win activation
public class WinUI : MonoBehaviour
{
    public GameObject winMenu;
    public string scene;

    public void WinMenuOpen()
    {
        winMenu.SetActive(true);
    }

    // Yes button
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
        winMenu.SetActive(false);
    }
}