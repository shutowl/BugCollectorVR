using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    int second, minute, hour;
    public Transform secondHand, minuteHand, hourHand;
    Vector3 secondRotation, minuteRotation, hourRotation;

    // Start is called before the first frame update
    void Start()
    {
        secondRotation = secondHand.rotation.eulerAngles;
        minuteRotation = minuteHand.rotation.eulerAngles;
        hourRotation = hourHand.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(moveHands());

    }

    IEnumerator moveHands()
    {
        second = DateTime.Now.Second;
        minute = DateTime.Now.Minute;
        hour = DateTime.Now.Hour;

        secondRotation.x = second * 6;
        minuteRotation.x = minute * 6;
        hourRotation.x = hour * 30;

        secondHand.rotation = Quaternion.Euler(secondRotation);
        minuteHand.rotation = Quaternion.Euler(minuteRotation);
        hourHand.rotation = Quaternion.Euler(hourRotation);

        yield return new WaitForSeconds(1);
        //Debug.Log("Time: " + hour + " " + minute + " " + second);
    }
}
