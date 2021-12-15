using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{

    /* Color color0 = Color.blue;


    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
       
        lt.color = color0;
    }*/
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.black;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    void Update()
    {
        // set light color
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }
}

