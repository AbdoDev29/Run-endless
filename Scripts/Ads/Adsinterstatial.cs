using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class Adsinterstatial : MonoBehaviour
{
    public string AndroidId;
    public string IosId;
    public bool Test;
    string adUnitId="";
    private void Start()
    {
        MobileAds.Initialize(Adsinterstatial => { });
        RequestInterstitial();
    }
    // Start is called before the first frame update
    #region interstitial
    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
        //this.interstitial.Show();
#if UNITY_ANDROID
        adUnitId = AndroidId;
#elif UNITY_IPHONE
            adUnitId = IosId;
#else
        string adUnitId = "unexpected_platform";
#endif
        if (Test)
        {
            adUnitId = "ca-app-pub-3940256099942544/1033173712";
        }

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            );
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpening event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
    public void GameOver()
    {
        //if (this.interstitial.IsLoaded())
        //{
            this.interstitial.Show();
        //}
    }
    #endregion
}
