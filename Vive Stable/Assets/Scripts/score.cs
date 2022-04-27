using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    //public Text text;
    public static int Score = 0;
    public static float Money = 1000f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //text.text = "Score: " + Score.ToString();
    }
    void OnGUI()
    {
        //GUI.Box(new Rect(50, 50, 200, 200), "Score: " + Score.ToString());

    }
}