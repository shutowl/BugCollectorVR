using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugMovement : MonoBehaviour
{
    public enum Behavior
    {
        Curious,
        Shy,
        Rotate
    };
    public Behavior behavior;

    public GameObject player;
    private Vector3 startPlayerPos;
    public int speed = 20;              //Determine speed of bug

    public float waveSpeed = 0.2f;      //Determine wave frequency
    public float waveHeight = 0.4f;     //Determine wave amplitude
    private float yStart;               //Starting wave y position (minimum)
    private float yEnd;                 //Ending wave y position   (maximum)

    public Text scoreText;              //Keeps track of the Score Text UI

    void Start()
    {
        yStart = transform.position.y;
        yEnd = transform.position.y + waveHeight;
        startPlayerPos = player.transform.position;
    }

    void Update()
    {
        switch (behavior.ToString().ToLower())
        {
            case ("curious"):
                break;
            case ("shy"):
                break;
            case ("rotate"):
                //Rotate around Player
                transform.RotateAround(startPlayerPos, Vector3.up, speed * Time.deltaTime);
                
                //Time bounces between 0 and 1 at a rate of waveSpeed
                float time = Mathf.PingPong(Time.time * waveSpeed, 1);

                //Ease in out function
                //Found here: https://easings.net/#easeInOutSine
                transform.position = Vector3.Lerp(new Vector3(transform.position.x, yStart, transform.position.z), 
                                                  new Vector3(transform.position.x, yEnd, transform.position.z), 
                                                  -(Mathf.Cos(Mathf.PI * time) - 1) / 2);
                
                break;
        }




    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "net")
        {
            score.Score++;
            scoreText.text = "Score: " + score.Score;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }


}

