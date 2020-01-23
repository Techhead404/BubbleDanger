using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    public float powerTime;
    
 
    public void OnTriggerEnter2D(Collider2D col)
    {
        //Need to change col tag set for ScoreZone for now
        if (col.gameObject.tag == "ScoreZone")
        {
            Camera.main.transform.rotation = new Quaternion(0f, 0, 180f,0f);
            StartCoroutine(WaitTime());
        }
      
    }


    IEnumerator WaitTime()
    {

         yield return new WaitForSeconds(powerTime);
         Camera.main.transform.rotation = new Quaternion(0f, 0, 0f, 0f);
    }
}
