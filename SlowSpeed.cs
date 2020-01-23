using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpeed : MonoBehaviour
{
    //How much it slows down >1 is slower <1faster
    private float slowDownFactor = .4f;
    //Time the power last?? Until I fix the WaitTime IEnumerator 
    private float deactivationPeriodDuration = 10f;
    private float deactivationElapsedTime;
    private float endEffect;
    Vector3 originalPos;
    private float powerTime = 10f ;



    private void Start()
    {

        originalPos = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //change tag from scorezone
        if (col.gameObject.tag == "ScoreZone")
        {
            
                StartCoroutine(SlowDown());

        }
      }

    IEnumerator SlowDown()
    {

        Time.timeScale = slowDownFactor;
        while (Time.time < endEffect)
        {           
            yield return null;           
        }

        deactivationElapsedTime = 0;

        while (deactivationElapsedTime < deactivationPeriodDuration)
        {
            Time.timeScale = Mathf.Lerp(slowDownFactor, 1, (deactivationElapsedTime / deactivationPeriodDuration));
            deactivationElapsedTime += Time.deltaTime;
            yield return null;
            gameObject.transform.localScale = originalPos;
            
        }

        
    }
    //forgot how to use IEnumerator need this to set the effect time correctly
    IEnumerator WaitTime()
   {
        
       yield return new WaitForSeconds(powerTime);
       transform.localScale = originalPos;
   }
    
}
