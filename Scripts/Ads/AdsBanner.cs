using UnityEngine;
using GoogleMobileAds.Api;
using System;


public class AdsBanner : MonoBehaviour {

    public string AndroidId;
    public string IosId;
    public bool Test;
    string adUnitId;
    private BannerView bannerView;
    
    public void Start()
    {
        this.RequestBanner();
    }
    #region Banner
    private void RequestBanner()
    {

#if UNITY_ANDROID
             adUnitId = AndroidId;
#elif UNITY_IPHONE
            adUnitId = IosId;
#else
        string adUnitId = "unexpected_platform";
#endif
        if (Test)
        {
            adUnitId = "ca-app-pub-3940256099942544/6300978111";
        }

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError.GetMessage());
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }
    #endregion
   


    //	void Awake ()
    //	{
    //#if UNITY_ANDROID
    //		#region Test ads Id
    //		//adMobAppID = "ca-app-pub-3940256099942544/3419835294";
    //		//AdBanner = "ca-app-pub-3940256099942544/6300978111";
    //		//AdInterstitial = "ca-app-pub-3940256099942544/1033173712";
    //		//videoAdMobId = "ca-app-pub-3940256099942544/5224354917";
    //		#endregion
    //				adMobAppID = "ca-app-pub-8298746660785054~1572110504";
    //				AdBanner = "ca-app-pub-8298746660785054/5494101693";
    //				AdInterstitial = "ca-app-pub-8298746660785054/5185026223";
    //				videoAdMobId = "ca-app-pub-8298746660785054/1656844756";
    //#elif UNITY_IPHONE
    //				adMobAppID = "ca-app-pub-8298746660785054~9108038253";
    //				AdBanner = "ca-app-pub-8298746660785054/7627683043";
    //				AdInterstitial = "ca-app-pub-8298746660785054/5304524618";
    //				videoAdMobId = "ca-app-pub-8298746660785054/9407421150";
    //#else
    //							string adUnitId = "unexpected_platform";
    //#endif
    //		gameObject.name = this.GetType().Name;
    //		//DontDestroyOnLoad(gameObject);
    //        if (PlayerPrefs.GetInt("ads") ==1)
    //        {

    //        }
    //        else
    //        {
    //			InitializeAds();
    //		}

    //	}


}
