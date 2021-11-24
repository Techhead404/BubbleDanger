using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using GooglePlayGames.BasicApi;
using GooglePlayGames;



public class GameManager : MonoBehaviour

{

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStarted;
    public static event GameDelegate OnGameOverConfirmed;

    public static GameManager Instance;


    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public Text scoreText;
    

    public string placementId = "video";
    private string gameID = "3111634";
    private bool testMode = false;
    public  int loadCount = 0;
    public string leaderboard = ;
    
    


    public void Start()
    {
        PlayGamesPlatform.Activate();
    }

    enum PageState
    {
        None,
        Start,
        Countdown,
        GameOver
    }
    
    
    int score = 0;
    bool gameOver = true;

    public bool GameOver { get { return gameOver; } }

   
    void Update()
    {
        //Monetization.Initialize(gameID, testMode);
        if (loadCount == 3)
        
        {
            Monetization.Initialize(gameID, testMode);
            loadCount = 0;
            ShowAd();
           
            
        }

       

        
    }
    void ShowAd()
    {

        StartCoroutine(ShowAdWhenReady());
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


void Awake()
{
    if (Instance != null)
    {
        Destroy(gameObject);
    }
    else
    {
        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }
}

    void OnEnable()
    {
        TapController.OnPlayerDied += OnPlayerDied;
        TapController.OnPlayerScored += OnPlayerScored;
        CountdownText.OnCountdownFinished += OnCountdownFinished;
    }

    void OnDisable()
    {
        TapController.OnPlayerDied -= OnPlayerDied;
        TapController.OnPlayerScored -= OnPlayerScored;
        CountdownText.OnCountdownFinished -= OnCountdownFinished;
    }

    void OnCountdownFinished()
    {
        SetPageState(PageState.None);
        OnGameStarted();
        score = 0;
        gameOver = false;
    }

    void OnPlayerScored()
    {
        score++;
        scoreText.text = score.ToString();
        
    }

    void OnPlayerDied()

    {
        loadCount++;
        gameOver = true;

        {
            if (Social.localUser.authenticated)
            {
                Social.ReportScore(score ,leaderboard , (bool success) => { });
            }
            int savedScore = PlayerPrefs.GetInt("HighScore" + gameObject.scene.name);
            if (score > savedScore)
            {
                PlayerPrefs.SetInt("HighScore" + gameObject.scene.name, score);

            }
            
            SetPageState(PageState.GameOver);

        }
    }

    void SetPageState(PageState state)
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                break;
        }
    }

    public void ConfirmGameOver()
    {
        
        SetPageState(PageState.Start);
        scoreText.text = "0";
        OnGameOverConfirmed();
    }

    public void StartGame()
    {
        SetPageState(PageState.Countdown);
    }
    


} 
