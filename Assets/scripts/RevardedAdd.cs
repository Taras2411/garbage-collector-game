using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Mediation;

public class RevardedAdd: MonoBehaviour {
  public string androidAdUnitId;
  public string iosAdUnitId;
  [SerializeField] private GameObject Canvas;
  IRewardedAd rewardedAd;  
  private GameObject player;


    
    


  async void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    // Initialize the package to access API
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
    // rewardedAd.Load();
  }

  // Implement load event callback methods:
  void AdLoaded(object sender, EventArgs args) {
    Debug.Log("Ad loaded.");
    ShowAd();
    // Execute logic for when the ad has loaded
  }

  void AdFailedToLoad(object sender, LoadErrorEventArgs args) {
    Debug.Log("Ad failed to load.");
    // Execute logic for the ad failing to load.
  }

  // Implement show event callback methods:
  void AdShown(object sender, EventArgs args) {
    Debug.Log("Ad shown successfully.");
    // Execute logic for the ad showing successfully.
  }

  void UserRewarded(object sender, RewardEventArgs args) {
    Debug.Log("Ad has rewarded user.");
    Canvas.GetComponent<canvasControler>().DisableAll();
    player.GetComponent<playerController>().enabled = true;
    player.GetComponent<playerController>().playerHealth = 1;

    // Execute logic for rewarding the user.
  }

  void AdFailedToShow(object sender, ShowErrorEventArgs args) {
    Debug.Log("Ad failed to show.");
    // Execute logic for the ad failing to show.
  }

  void AdClosed(object sender, EventArgs e) {
    Debug.Log("Ad is closed.");
    // Execute logic for the user closing the ad.
  }

  public void ShowAd() { 
    // Ensure the ad has loaded, then show it.
    
    if (rewardedAd.AdState == AdState.Loaded) {
      Debug.Log("Ad is loaded. Showing ad.");
      rewardedAd.Show();
    }else{
      Debug.Log("Ad is not loaded yet. So, wait for it to load.");
      rewardedAd.Load();
    }
  }
}