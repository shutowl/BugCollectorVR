using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class fly : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update

    private Vector3 RandomVector(float min, float max)
    {
        //Random.InitState(System.Environment.TickCount);
        Random.seed = GetInstanceID();
        float x = Random.Range(min, max); ;
        float y = Random.Range(0f, max); ;
        float z = Random.Range(min, max); ;
        return new Vector3(x, y, z);
    }



    // Update is called once per frame
    //public float period = 0.0f;
    public float min = -5f, max = 5f;
    public float speed = 1;

    public float x_range = 10, y_range = 10, z_range = 10;
    public int rotationFactor = 2;

    private static Vector3 controlVector;
    private Vector3 rotate_Vector;

    private bool first = true;




    


    void Start()
    {

        controlVector = RandomVector(min, max);
        rotate_Vector = new Vector3(0, controlVector.y, 0);
    }

    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();

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
        transform.Rotate(rotate_Vector * Time.deltaTime * rotationFactor);
        //transform.rotation = Random.rotation;

        //period += UnityEngine.Time.deltaTime;

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);



        Vector3 currentPosition = transform.position;

        currentPosition.y = Mathf.Clamp(currentPosition.y, 0, y_range);
        currentPosition.x = Mathf.Clamp(currentPosition.x, -x_range, x_range);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -z_range, z_range);

        transform.position = currentPosition;



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
        else
        {

        }
    }


}
