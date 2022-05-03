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

    [SerializeField] private GameObject player;
    private Vector3 startPlayerPos;
    public int speed = 20;              //Determine speed of bug

    public float waveSpeed = 0.2f;      //Determine wave frequency
    public float waveHeight = 0.4f;     //Determine wave amplitude
    private float yStart;               //Starting wave y position (minimum)
    private float yEnd;                 //Ending wave y position   (maximum)

    [SerializeField] private Text scoreText;              //Keeps track of the Score Text UI
    [SerializeField] private Text moneyText;

    public int points;                  //how many points the bug is worth
    public float value = 30f;           //how much the bug is worth

    public Vector3 maxPos;
    public Vector3 minPos;
    Vector3 newPos;

    private float timer = 0f;
    void Start()
    {
        yStart = transform.position.y;
        yEnd = transform.position.y + waveHeight;
        startPlayerPos = player.transform.position;
        newPos = transform.position;
        points = (int)value * 10;
    }

    void Update()
    {
        switch (behavior.ToString().ToLower())
        {
            case ("curious"):
                if (Vector3.Distance(transform.position, newPos) > 0.001f)                                          //if not at newPos
                {
                    transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime / 5); //keep moving towards newPos
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, transform.position - newPos, speed * Time.deltaTime, 0.0f);
                    transform.rotation = Quaternion.LookRotation(newDirection);                                     //and rotate towards newPos
                }
                else                                                                                                //if at newPos
                {
                    if (timer > Random.Range(1, 3))                                                                 //Wait a few seconds before moving again
                    {
                        newPos = new Vector3(Random.Range(minPos.x, maxPos.x), 0, Random.Range(minPos.z, maxPos.z));
                        timer = 0f;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
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
    void Die() //dying is a function so it can be called outside of just being hit with a net (powerups?)
    {
        score.Money += value;
        moneyText.text = "Money: $" + score.Money;
        score.Score += points;
        scoreText.text = "Score: " + score.Score;

        Spawner.bugCaught();
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void HitByDebris()
    {
        speed = Mathf.Clamp(speed / 2, 1, speed);
        value = Mathf.Clamp(value - 10, 10, value);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "net")
        {
            Die();
        }
        if (collision.gameObject.tag == "Debris")
        {
            HitByDebris();
        }
    }


}

