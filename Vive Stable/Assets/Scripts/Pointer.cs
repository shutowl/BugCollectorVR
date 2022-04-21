using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class Pointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Menu menu;

    void Start()
    {
        laserPointer.Begin();
    }

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Test Button")
        {
            menu.testButton();
            //Debug.Log("Test Button was clicked");
        }
        if(e.target.name == "Reset Net Button")
        {
            menu.resetNet();
            //Debug.Log("Reset Net Button was clicked");
        }
        if (e.target.name == "Reset Player Button")
        {
            menu.resetPlayer();
            //Debug.Log("Reset Player Button was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Canvas" || e.target.name == "Test Button" || e.target.name == "Reset Net Button" || e.target.name == "Reset Player Button")
        {
            Debug.Log("Canvas was entered");
            laserPointer.setActive();

        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Canvas")
        {
            laserPointer.setInactive();

            Debug.Log("Canvas was exited");
        }
    }
}
