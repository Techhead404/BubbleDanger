using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbletrig : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        {

            if (other.gameObject.tag == "DeadZone")
            {
                GetComponent<SpriteRenderer>().enabled = false;
                
            }

            //     Destroy(other.gameObject);
        }
    }
}
