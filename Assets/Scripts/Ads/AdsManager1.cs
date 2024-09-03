using UnityEngine;

using System;


public class AdsManager1 : MonoBehaviour
{


	[Space(15)]


	static AdsManager1 instance;

	public static AdsManager1 Instance
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType(typeof(AdsManager1)) as AdsManager1;

			return instance;
		}
	}


	void Awake()
	{
#if UNITY_ANDROID

#elif UNITY_IPHONE
			
#else
						
#endif
		gameObject.name = this.GetType().Name;
		//DontDestroyOnLoad(gameObject);
		if (PlayerPrefs.GetInt("ads") == 1)
		{

		}
		else
		{

		}

	}

	public void ShowInterstitial()
	{
		GetComponent<Adsinterstatial>().GameOver();
		

	}



	public void ShowVideoReward()
	{
		
		GetComponent<RewardedAds>().UserChoseToWatchAd();
	}




	void Start()
	{
		Time.timeScale = 1.0f;
	}






}
