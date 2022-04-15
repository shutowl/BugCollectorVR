using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text scoreText;
    public Transform net;
    private Vector3 startNetPos;

    void Start()
    {
        startNetPos = net.transform.position;
    }

    public void testButton()
    {
        score.Score += 1000;
        scoreText.text = "Score: " + score.Score;
        Debug.Log("Button Clicked");
    }

    public void resetNet()
    {
        net.position = startNetPos;
    }
}
