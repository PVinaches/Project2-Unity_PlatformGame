using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Text text;

    // Uodate the score text with the data from PlayerCharacter
    public void UpdateText(int score)
    {
        text.text = "Score: " + score.ToString();
    }
}
