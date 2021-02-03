using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Game Over activation
public class DeathUI : MonoBehaviour
{
    public GameObject deathMenu;
    public string scene;

    public void DeathMenuOpen()
    {
        deathMenu.SetActive(true);
    }

    // Restart button
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
        deathMenu.SetActive(false);
    }
}
