using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Text scoreText;
    private Text moneyText;
    public Transform net;
    public Transform player;
    private Vector3 startNetPos;
    private Quaternion startNetRot;
    private Vector3 startNetScale;
    private Vector3 startPlayerPos;

    void Start()
    {
        startNetPos = net.transform.position;
        startNetRot = net.transform.rotation;
        startNetScale = net.localScale;
        startPlayerPos = player.transform.position;

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        scoreText.text = "Score: " + score.Score;
        moneyText.text = "Money: $" + score.Money;
    }

    public void testButton()
    {
        score.Score += 1000;
        scoreText.text = "Score: " + score.Score;
        Debug.Log("Button Clicked");
    }

    public void resetNetPos()
    {
        net.position = startNetPos;
        net.rotation = startNetRot;
    }

    public void resetNetSize()
    {
        net.localScale = startNetScale;
    }

    public void resetPlayer()
    {
        player.position = startPlayerPos;
    }

    public void buyNet()
    {
        if(score.Money >= 500)
        {
            Vector3 netScale = net.localScale;
            netScale.x += 0.03f;
            netScale.y += 0.03f;
            netScale.z += 0.03f;
            net.localScale = netScale;

            score.Money -= 500;
            moneyText.text = "Money: $" + score.Money;
        }
    }
}
