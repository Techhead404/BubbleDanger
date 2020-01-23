using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private int powerNumber;
    public GameObject FastPower;
    public GameObject SlowPower;
    
    public void Start()
    {
        Powerup();
        
    }
    public void Update()
    {

        
        
        

       


    }
    public void Powerup()
    {
        int power = Random.Range(0,5);
            
        if (power == 0 )
        {
            Debug.Log(0);
            //GetComponent<GameObject>();
            Instantiate <GameObject>(FastPower);
            
        }
        if (power == 1)
        {
            Debug.Log(1);
            //GetComponent<PlayerPrefs>();
            Instantiate<GameObject>(SlowPower);
        }
        if (power == 2)
        {
            Debug.Log(2);
            GetComponent<PlayerPrefs>();

        }
        if (power == 3)
        {
            Debug.Log(3);
            GetComponent<PlayerPrefs>();

        }
        if (power == 4)
        {
            Debug.Log(4);
            GetComponent<PlayerPrefs>();

        }
        if (power == 5)
        {
            Debug.Log(5);
            GetComponent<PlayerPrefs>();

        }
    }
 
}
