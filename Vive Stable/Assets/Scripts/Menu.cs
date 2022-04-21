using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text scoreText;
    public Transform net;
    public Transform player;
    private Vector3 startNetPos;
    private Quaternion startNetRot;
    private Vector3 startPlayerPos;

    void Start()
    {
        startNetPos = net.transform.position;
        startNetRot = net.transform.rotation;
        startPlayerPos = player.transform.position;
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
        net.rotation = startNetRot;
    }

    public void resetPlayer()
    {
        player.position = startPlayerPos;
    }
}
