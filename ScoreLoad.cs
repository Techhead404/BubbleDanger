using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreLoad : MonoBehaviour


    
{
    Text hscore;
    
    public string lvlname = "";
    


    void Start()
    {
        hscore = GetComponent<Text>();
        hscore.text = "High Score:" + PlayerPrefs.GetInt("HighScore" + lvlname ).ToString();
        


    }

}
