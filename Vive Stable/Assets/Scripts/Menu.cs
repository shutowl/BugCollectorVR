using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text scoreText;

    public void testButton()
    {
        score.Score += 1000;
        scoreText.text = "Score: " + score.Score;
        Debug.Log("Button Clicked");
    }
}
