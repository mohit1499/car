using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatewater : MonoBehaviour
{
    // Start is called before the first frame update
public float SpeedX;
public float SpeedY;
private float CurrX;
private float CurrY;
    void Start()
    {
        CurrX= GetComponent<Renderer>().material.mainTextureOffset.x;
        CurrY= GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    void Update()
    {
        CurrX +=Time.deltaTime*SpeedX;
        CurrY +=Time.deltaTime*SpeedY;  
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(CurrX,CurrY));  
    }
}
