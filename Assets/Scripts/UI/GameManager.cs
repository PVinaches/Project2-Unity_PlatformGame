using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded;
    
    // Game Over
    public void EndGame(int score)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Time.timeScale = 0f;

            FindObjectOfType<GameMarkers>().GameMarkersInactive();

            if (score > 59)
            {
                FindObjectOfType<WinUI>().WinMenuOpen();
            }
            else
            {
                FindObjectOfType<DeathUI>().DeathMenuOpen();
            }
        }
    }
}
