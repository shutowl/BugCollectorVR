using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public enum Behavior
    {
        Curious,
        Shy,
        Rotate
    };
    public Behavior behavior;

    public GameObject player;
    public int speed = 20;

    //private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        //position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (behavior.ToString().ToLower())
        {
            case ("curious"):
                break;
            case ("shy"):
                break;
            case ("rotate"):
                //Rotate around Player
                transform.RotateAround(player.transform.position, Vector3.up, speed * Time.deltaTime);
                break;
        }


    }


}

