using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{
   public AudioSource clankSound;

    void Start()
    {
        clankSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {

        //if (collision.relativeVelocity.magnitude > 1){
            if (!clankSound.isPlaying && collision.gameObject.tag != "bug")
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
