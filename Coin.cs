using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        {

            if (other.gameObject.tag == "Player")
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }

            
        }
    }

}
