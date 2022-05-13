using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
    [Tooltip("Sound that plays when the net hits something.")]
    public AudioSource clankSound;

    void Start()
    {
        clankSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {

        //if (collision.relativeVelocity.magnitude > 1){
        if (!clankSound.isPlaying && (collision.gameObject.tag == "terrain" || collision.gameObject.tag == "debris"))
        {
            clankSound.Play();
        }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
