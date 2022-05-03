using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Fly : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text moneyText;
    private int points;                 //how many points the bug is worth
    public float value = 30f;           //how much the bug is worth

    //public float period = 0.0f;
    public float min = -5f, max = 5f;
    public float speed = 1;

    public float x_range = 10, y_range = 10, z_range = 10;
    public int rotationFactor = 2;

    private Vector3 controlVector;
    private Vector3 rotate_Vector;

    //private bool first = true;

    void Start()
    {
        controlVector = RandomVector(min, max);
        rotate_Vector = new Vector3(0, controlVector.y, 0);

        points = (int)value * 10;
        var rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {


        if (Vector3.Distance(transform.position, controlVector) < 0.001f)
        {
            //Random.seed = System.DateTime.Now.Millisecond;
            controlVector = RandomVector(min, max);
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

        currentPosition.y = Mathf.Clamp(currentPosition.y, 0, y_range);
        currentPosition.x = Mathf.Clamp(currentPosition.x, -x_range, x_range);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -z_range, z_range);

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
