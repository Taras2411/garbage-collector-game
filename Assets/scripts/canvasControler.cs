using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Mediation;

public class canvasControler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ContinueScreen;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject BackGround;

    [SerializeField] private GameObject Loading;
    [SerializeField] private GameObject FailedToLoad;
    [SerializeField] int waitTime;
    bool isLoading = false;
    float lastLoadTime;

    private GameObject player;
    
    public string androidAdUnitId;
    public string iosAdUnitId;
    IRewardedAd rewardedAd;  
    async void Start(){
        //find player object by tag 
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("player found" + player.name);

        await UnityServices.InitializeAsync();

        // Instantiate a rewarded ad object with platform-specific Ad Unit ID
        if (Application.platform == RuntimePlatform.Android) {
          rewardedAd = new RewardedAd(androidAdUnitId);
        } else if (Application.platform == RuntimePlatform.IPhonePlayer) {
          rewardedAd = new RewardedAd(iosAdUnitId);
        }
        #if UNITY_EDITOR
        else {
          rewardedAd = new RewardedAd("myExampleAdUnitId");
        }
        #endif

        // Subscribe callback methods to load events:
        rewardedAd.OnLoaded += AdLoaded;
        rewardedAd.OnFailedLoad += AdFailedToLoad;

        // Subscribe callback methods to show events:
        rewardedAd.OnShowed += AdShown;
        rewardedAd.OnFailedShow += AdFailedToShow;
        rewardedAd.OnUserRewarded += UserRewarded;
        rewardedAd.OnClosed += AdClosed;

    }
    void Update()
    {
      if(Time.time - lastLoadTime > 10f && isLoading){
        Debug.Log("Ad failed to load.");
        DisableAll();
        BackGround.SetActive(true);
        FailedToLoad.SetActive(true);
      }
    }
    public void changeActiveState(bool state)
    {
        BackGround.SetActive(state);
        ContinueScreen.SetActive(state);
        GameOverScreen.SetActive(false);
        GameObject.Find("Timer").GetComponent<Image>().fillAmount = 1f;

        StartCoroutine(CountDown());

        

    }
    public void DisableAll(){
        BackGround.SetActive(false);
        ContinueScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        Loading.SetActive(false);
        FailedToLoad.SetActive(false);
    }
    public void GameOver()
    {
       
      DisableAll();
      BackGround.SetActive(true);
      GameOverScreen.SetActive(true);

    }
    public void ShowAd()
    {
      isLoading = true;
      lastLoadTime = Time.time;
      StopAllCoroutines();
      ContinueScreen.SetActive(false);
      Loading.SetActive(true);

      if (rewardedAd.AdState == AdState.Loaded) {
        Debug.Log("Ad is loaded. Showing ad.");
        rewardedAd.Show();
      }else{
        Debug.Log("Ad is not loaded yet. So, wait for it to load.");
        rewardedAd.Load();
      }
    }
    IEnumerator CountDown()
    {

        float FrameRate = 1.0f / Time.deltaTime;
        //clamp the framerate to a max of 60fps
        FrameRate = Mathf.Clamp(FrameRate, 0f, 60f);
        int amountOfSteps = waitTime * (int)FrameRate;
        if(GameObject.Find("Timer").GetComponent<Image>().fillAmount> 0.0001f){
            for(int i = 0; i < amountOfSteps; i++)
            {
                GameObject.Find("Timer").GetComponent<Image>().fillAmount -= 1f/amountOfSteps;
                yield return null;
            }
            Debug.Log("Game Over");
            player.GetComponent<playerController>().enabled = false; 
            GameOver();

        }
        
    }


    void AdLoaded(object sender, EventArgs args) {
    Debug.Log("Ad loaded.");
    ShowAd();
    // Execute logic for when the ad has loaded
  }

    void AdFailedToLoad(object sender, LoadErrorEventArgs args) {
    Debug.Log("Ad failed to load.");
    DisableAll();
    BackGround.SetActive(true);
    FailedToLoad.SetActive(true);
    // Execute logic for the ad failing to load.

  }

  // Implement show event callback methods:
  void AdShown(object sender, EventArgs args) {
    Debug.Log("Ad shown successfully.");
    isLoading = false;
    // Execute logic for the ad showing successfully.
  }

  void UserRewarded(object sender, RewardEventArgs args) {
    Debug.Log("Ad has rewarded user.");
    DisableAll();
    player.GetComponent<playerController>().enabled = true;
    player.GetComponent<playerController>().playerHealth = 1;

    // Execute logic for rewarding the user.
  }

  void AdFailedToShow(object sender, ShowErrorEventArgs args) {
    Debug.Log("Ad failed to show.");
    DisableAll();
    BackGround.SetActive(true);
    FailedToLoad.SetActive(true);
    // Execute logic for the ad failing to show.
  }

  void AdClosed(object sender, EventArgs e) {
    Debug.Log("Ad is closed.");
    // DisableAll();
    // BackGround.SetActive(true);s
    // GameOverScreen.SetActive(true);


    // Execute logic for the user closing the ad.
  }








}
