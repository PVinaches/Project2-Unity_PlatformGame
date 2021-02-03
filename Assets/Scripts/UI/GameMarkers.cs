using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Activate and deactivate the gamemarkers (score and healthbar)
public class GameMarkers : MonoBehaviour
{
    public GameObject gameMarkersMenu;
    
    void Start()
    {
        gameMarkersMenu.SetActive(true);
    }

    public void GameMarkersInactive()
    {
        gameMarkersMenu.SetActive(false);
    }
}
