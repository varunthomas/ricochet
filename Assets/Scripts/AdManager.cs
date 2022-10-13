using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class AdManager : MonoBehaviour
{
	private RewardedAd rewardedAd;
	public GameObject ContinueUI;
 
	public void Start()
	{

	}

    public void RequestRewardedVideo()
    {
        string adUnitId;
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-2913259568136341~3123910376";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-2913259568136341/8812147487";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
		Debug.Log("a");
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
		Debug.Log("ab");
       /* MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);*/
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
		Debug.Log("ac");
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
		Debug.Log("ad");
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
		Debug.Log("ae");
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
		Debug.Log("af");
		ContinueUI.SetActive(false);
		GameManager.instance.continue_game = true;
		SceneGenerator.instance.generateBall(5);
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
	
	public void ShowAd()
	{
		MobileAds.Initialize(initialize => {});
		RequestRewardedVideo();
		
		if( rewardedAd.IsLoaded())
			rewardedAd.Show();
	}
	
	public void SkipAd()
	{
		GameManager.instance.SetHighScore();
		SceneManager.LoadScene("Game");
	}
}
