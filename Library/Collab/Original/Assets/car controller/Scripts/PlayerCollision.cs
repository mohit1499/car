using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  //  public LightChange change;
   
    
    /*void OnCollisionEnter (Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            change.enabled = true;
            Debug.Log("running");
        }
    }

     */
    void OnCollisionEnter()
    {
        Debug.Log("running");
    }
    
   
}
