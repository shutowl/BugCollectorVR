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
    void Update()
    {
        var rb = GetComponent<Rigidbody>();
        if (period > 0.1)
        {
            //Do Stuff
            period = 0;
            rb.velocity = RandomVector(-5f, 5f);
        }
        period += UnityEngine.Time.deltaTime;


    }
    //Dissappear
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Stick")
        {
            gameObject.SetActive(false);

        }
        else
        {

        }
    }
}
