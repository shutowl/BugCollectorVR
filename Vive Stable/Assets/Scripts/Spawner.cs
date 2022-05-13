using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnSpeed = 2f;       //Bugs spawn once every (spawnSpeed) seconds
    private float timer = 0;            //local timer
    public int maxBugs = 20;            //Max number of bugs allowed on the field

    [SerializeField] private int bugsLeftSerialize;
    static int bugsLeft = 0;            //Counts how many bugs are still uncaught

    public GameObject[] bugs;

    public Transform[] spawnPos;        //Position of spawns

    //public GameObject net;

    private void Start()
    {
        //Instantiate(net, new Vector3(-1f, 1f, -0.5f), Quaternion.identity);
    }

    void Update()
    {
        if (bugsLeft < maxBugs)
        {
            if (timer > spawnSpeed)
            {
                SpawnFlyingBug();
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        //bugs = GameObject.FindGameObjectsWithTag("Bug");
        //bugsLeft = bugs.Length;
        bugsLeftSerialize = bugsLeft;
    }

    public static void bugCaught()
    {
        bugsLeft--;
    }

    void SpawnFlyingBug()
    {
        Instantiate(bugs[Random.Range(0, bugs.Length)], spawnPos[Random.Range(0, spawnPos.Length)].position, Quaternion.identity);        //Creates a random bug at one of the spawn points
        bugsLeft++;
    }


}