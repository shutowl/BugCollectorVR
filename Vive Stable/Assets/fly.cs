using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fly : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    void Start()
    {

    }

    // Update is called once per frame
    public float period = 0.0f;
    public float min = -5f, max = 5f;
    public float speed = 0f;

    public float x_range = 10, y_range = 10, z_range = 10;





    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        if (period > 0.1)
        {

            period = 0;
            rb.velocity = RandomVector(min, max);
        }
        period += UnityEngine.Time.deltaTime;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);


        Vector3 currentPosition = transform.position;

        currentPosition.y = Mathf.Clamp(currentPosition.y, 0, y_range);
        currentPosition.x = Mathf.Clamp(currentPosition.x, -x_range, x_range);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -z_range, z_range);

        transform.position = currentPosition;



    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Stick")
        {
            score.Score = score.Score + 1;
            gameObject.SetActive(false);
            //Destroy(gameObject);

        }
        else
        {

        }
    }


}
