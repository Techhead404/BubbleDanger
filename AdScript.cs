using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;



public class AdScript : MonoBehaviour
{
    public string placementId = "video";
    private string gameID = "3111634";
    bool testMode = true;
   

    void Start()
    {
        Monetization.Initialize(gameID, testMode);
        
        {

         
            ShowAd();

        }

    
      void ShowAd()
        {
          
            StartCoroutine(ShowAdWhenReady());
        }
    }

    private IEnumerator ShowAdWhenReady()
    {
        while (!Monetization.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show();
        }
    }
}



