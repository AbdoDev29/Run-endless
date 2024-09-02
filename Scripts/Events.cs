using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class Events : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerController playerController;
    RewardedAds rewardedAds;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject resum;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject continuePanal;
    public  bool ispause = false;
    public  bool isresum = false;
    public bool isDied = false;
    public TextMeshProUGUI adsText;
    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerController = FindObjectOfType<PlayerController>();
        rewardedAds = FindObjectOfType<RewardedAds>();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("LevelOne");
        
    }
       




    public void Pause()
    {
        ispause = true;
        resum.SetActive(true);
        pause.SetActive(false);
    }

    public void Resumption()
    {
       
        ispause = false;
        Time.timeScale = 1;
        resum.SetActive(false);
        pause.SetActive(true);
    }

 
    public void StopIntegrationAd()
    {
        cam.GetComponent<AudioListener>().enabled = false;
        PlayerManager.stopped = true;
        isDied = true;
        playerController.moveSpeed = 0;
        playerController.isWatchAd = true;
        continuePanal.SetActive(false);
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
   public void PlayIntegrationAd()
    {
        if (!rewardedAds.isLoadingAd)
        {
            adsText.enabled = true;
            adsText.text = "The ad is not available now";
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
