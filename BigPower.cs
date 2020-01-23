using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPower : MonoBehaviour
{
    private float x;
    private float y;
    private float z;
    Vector3 originalPos;
    public float powerTime;

    private void Start()
    {
        originalPos = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        //Need to change col tag set for ScoreZone for now
        if (col.gameObject.tag == "PowerUp")
        {
            
            x = 6f;
            y = 6f;
            transform.localScale = new Vector3(x, y, z);
            StartCoroutine(WaitTime());
        }
    }


    IEnumerator WaitTime()
    {

        yield return new WaitForSeconds(powerTime);
        transform.localScale = originalPos;
    }
}
