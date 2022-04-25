using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;
using UnityEngine.UI;




public class CurForAD : MonoBehaviour
{
    public GameObject Loading;
    public string androidAdUnitId;
    public string iosAdUnitId;
    IRewardedAd rewardedAd;
    int amount;
    string prefabName;


    
    async void Start()
    {
        await UnityServices.InitializeAsync();
    
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

        rewardedAd.OnLoaded += AdLoaded;
        rewardedAd.OnFailedLoad += AdFailedToLoad;

        rewardedAd.OnShowed += AdShown;
        rewardedAd.OnFailedShow += AdFailedToShow;
        rewardedAd.OnUserRewarded += UserRewarded;
        rewardedAd.OnClosed += AdClosed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdLoaded(object sender, EventArgs args) {
      Debug.Log("Ad loaded.");
      rewardedAd.Show();
      // Execute logic for when the ad has loaded
    }   
    void AdFailedToLoad(object sender, LoadErrorEventArgs args) {
      Debug.Log("Ad failed to load.");
      // Execute logic for the ad failing to load.
    }   
    // Implement show event callback methods:
    void AdShown(object sender, EventArgs args) {
      Debug.Log("Ad shown successfully.");
      Loading.SetActive(false);
      // Execute logic for the ad showing successfully.
    }   
    void UserRewarded(object sender, RewardEventArgs args) {
        Debug.Log("Ad has rewarded user.");
        //add amount to player prefs
        PlayerPrefs.SetInt(prefabName, PlayerPrefs.GetInt(prefabName, 0) + amount); 
        
    }   
    void AdFailedToShow(object sender, ShowErrorEventArgs args) {
      Debug.Log("Ad failed to show.");
      // Execute logic for the ad failing to show.
    }   
    void AdClosed(object sender, EventArgs e) {
      Debug.Log("Ad is closed.");
      // Execute logic for the user closing the ad.
    }
    void ShowAdForCur(string _PrefabName, int _amount)
    {
        amount = _amount;
        prefabName = _PrefabName;
        Loading.SetActive(true);
        rewardedAd.Load();


    }
    public void ShowAdForBTC(int __amount)
    {
        ShowAdForCur("BTC", __amount);
    }
    public void ShowAdForUSD(int __amount)
    {
        ShowAdForCur("USD", __amount);
    }
    



}
