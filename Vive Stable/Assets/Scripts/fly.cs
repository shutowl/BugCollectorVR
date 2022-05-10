using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Fly : MonoBehaviour
{

    [Header("Movement Variables")]
    public float minRandom = -5f; [Tooltip("Random vector change minimum value.")]
    public float maxRandom = 5f; [Tooltip("Random vector change maximum value.")]
    public float speed = 1; [Tooltip("How quickly the bug moves.")]
    private float tempSpeed;
    public float x_range = 10, y_range = 10, z_range = 10;
    public Vector3 range = new Vector3(10, 10, 10); [Tooltip("Range of flying movement.")]
    public int rotationFactor = 2;
    private Vector3 controlVector;
    private Vector3 rotate_Vector;
    [SerializeField] private float period = 0.0f;

    [Header("Money and Points Text UI")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text moneyText;

    [Header("Money and Points Values")]
    private int points;                 //how many points the bug is worth
    public float value = 30f;           //how much the bug is worth

    //private bool first = true;
    [Header("Death Animation")]
    public float targetScale = 0.01f; [Tooltip("Scale for death animation.")]
    public float timeToLerp = 0.25f; [Tooltip("Time for death animation.")]
    float scaleModifier = 1;

    void Start()
    {
        //Assign gameobjects because prefabs still need to find them
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        controlVector = RandomVector(minRandom, maxRandom);
        rotate_Vector = new Vector3(0, controlVector.y, 0);

        points = (int)value * 10;
        tempSpeed = speed;
    }

    void Update()
    {
        //Create a new vector to fly towards
        if (Vector3.Distance(transform.position, controlVector) < 0.001f)
        {
            //Random.seed = System.DateTime.Now.Millisecond;
            controlVector = RandomVector(minRandom, maxRandom);
            rotate_Vector = new Vector3(0, controlVector.y, 0);

        }

        //Check and react if the net is nearby
        if (period > 0.5)
        {
            if (Vector3.Distance(transform.position, GameObject.FindWithTag("net").transform.position) < 1f)
            {
                //Debug.Log(GameObject.FindWithTag("net").transform.position);
                tempSpeed = speed;
                speed = speed * 2;
                controlVector = RandomVector(minRandom, maxRandom);
                rotate_Vector = new Vector3(0, controlVector.y, 0);

            }
            else
            {
                speed = tempSpeed;
            }
            period = 0;


        }
        period += Time.deltaTime;

        //move towards new location
        transform.position = Vector3.MoveTowards(transform.position, controlVector, Time.deltaTime * speed);

        //rotate towards location
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, controlVector - transform.position, speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        Vector3 currentPosition = transform.position;

        currentPosition.y = Mathf.Clamp(currentPosition.y, 0, y_range);
        currentPosition.x = Mathf.Clamp(currentPosition.x, -x_range, x_range);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -z_range, z_range);

        transform.position = currentPosition;



    }
    void Die() //dying is a function so it can be called outside of just being hit with a net (powerups?)
    {
        StartCoroutine(LerpScale(targetScale, timeToLerp));

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
        points = (int)value * 10;
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

    IEnumerator LerpScale(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * endValue;
        scaleModifier = endValue;
    }

    private Vector3 RandomVector(float min, float max)
    {
        //Random.InitState(System.Environment.TickCount);
        //Random.InitState(GetInstanceID());
        float x = Random.Range(min, max); ;
        float y = Random.Range(0f, max); ;
        float z = Random.Range(min, max); ;
        return new Vector3(x, y, z);
    }


}
