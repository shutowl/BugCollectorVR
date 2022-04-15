using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float period = 0;
    public GameObject butterfly;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(period > 2)
        {
            Instantiate(butterfly, new Vector3(0, 0, 0), Quaternion.identity);
            period = 0;
        }
        period += Time.deltaTime;
    }
}
