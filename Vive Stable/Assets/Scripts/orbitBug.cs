using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class orbitBug : MonoBehaviour
{
    private Text scoreText;
    private Text moneyText;
    private int points;                 //how many points the bug is worth
    public float value = 30f;           //how much the bug is worth

    //public float period = 0.0f;
    public float min = -5f, max = 5f;
    public float speed = 3;

    public float x_range = 10, y_range = 10, z_range = 10;
    public int rotationFactor = 2;

    private Vector3 controlVector;
    private Vector3 rotate_Vector;
    public float period = 0.0f;

    //private bool first = true;

    public float radius = 10.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 10.0f;


    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
        points = (int)value * 10;
    }

    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        transform.RotateAround(GameObject.Find("Player").transform.position, new Vector3(0, 5, 0), rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - GameObject.Find("Player").transform.position).normalized * radius + GameObject.Find("Player").transform.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

        rotationSpeed += UnityEngine.Time.deltaTime/2;
        if (period > 2f)
        {
            radius = radius - 0.1f;
            period = 0;

        }
        period += UnityEngine.Time.deltaTime;

        //If the bug gets too close to player
        if(radius < 1){
               gameObject.SetActive(false);
        }



    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "net")
        {
            score.Money += value;
            moneyText.text = "Money: $" + score.Money;
            score.Score += points;
            scoreText.text = "Score: " + score.Score;

            Spawner.bugCaught();

            gameObject.SetActive(false);
            Destroy(gameObject);


        }
        if (collision.gameObject.tag == "Debris")
        {
            score.Score -= points;
            scoreText.text = "Score: " + score.Score;
        }
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);

        }

    }



}