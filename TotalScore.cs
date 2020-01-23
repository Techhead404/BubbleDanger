using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{

    Text tscore;
    public string lvlname = "";
    public string lvl1 = "";
    public string lvl2 = "";
    public string lvl3 = "";
    public string lvl4 = "";

    void Start()
    {
        tscore = GetComponent<Text>();
        tscore.text = "High Score:" + PlayerPrefs.GetInt("HighScore").ToString();



    }
}
