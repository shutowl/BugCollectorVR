using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Fly : MonoBehaviour
{

    [Header("Movement Variables")]
    //public float period = 0.0f;
    public float minRandom = -5f; [Tooltip("Random vector change minimum value.")]
    public float maxRandom = 5f; [Tooltip("Random vector change maximum value.")]
    public float speed = 1; [Tooltip("How quickly the bug moves.")]
    public float x_range = 10, y_range = 10, z_range = 10;
    public Vector3 range = new Vector3(10, 10, 10); [Tooltip("Range of flying movement.")]
    public int rotationFactor = 2;
    private Vector3 controlVector;
    private Vector3 rotate_Vector;

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
        controlVector = RandomVector(minRandom, maxRandom);
        rotate_Vector = new Vector3(0, controlVector.y, 0);

        points = (int)value * 10;
        var rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


        if (Vector3.Distance(transform.position, controlVector) < 0.001f)
        {
            //Random.seed = System.DateTime.Now.Millisecond;
            controlVector = RandomVector(minRandom, maxRandom);
            rotate_Vector = new Vector3(0, controlVector.y, 0);

        }
        //movement

        //transform.position += update_position * Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, controlVector, Time.deltaTime * speed);
        // checking_vector = transform.position;

        //Debug.Log(controlVector);
        // // Debug.Log(checking_vector);
        // Debug.ClearDeveloperConsole();
        //Debug.Log(GetInstanceID());

        //rotate
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, controlVector - transform.position, speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        //transform.rotation = Random.rotation;

        //period += UnityEngine.Time.deltaTime;

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);



        Vector3 currentPosition = transform.position;

        currentPosition.y = Mathf.Clamp(currentPosition.y, 0, range.y);
        currentPosition.x = Mathf.Clamp(currentPosition.x, -range.x, range.x);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -range.z, range.z);

        transform.position = currentPosition;



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
