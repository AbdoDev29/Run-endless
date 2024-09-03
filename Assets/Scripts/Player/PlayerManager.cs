using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject panelContinue;

 
    [SerializeField] private GameObject UITween;
    [SerializeField] private GameObject[] panelsDisactive,panelsActive;
    private  Events events;
    public static bool stopped;
   // public static bool isGameStarted = true;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI totalText; //
    public static int totalScore; //
 
    [SerializeField] TextMeshProUGUI coinText1;
    public static int coinScore1; 
    
    [SerializeField] TextMeshProUGUI coinText2;
    public static int coinScore2;

    [Header("Panels")]
    public float timer;
    public bool isClickOnAd = false;
    [SerializeField] Image fillImage; // stop Watch


    void Start()
    {

        coinScore1 = 0;
        coinScore2 = 0;
        stopped = false;

        events = FindObjectOfType<Events>();
        
       

        if (PlayerPrefs.HasKey("score"))
        {
            totalScore = PlayerPrefs.GetInt("score");
        }
    }

    void Update()
    {
        PlayerPrefs.SetInt("score", totalScore);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            coinText1.text = coinScore1.ToString();
            coinText2.text = coinScore2.ToString();
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
            totalText.text = totalScore.ToString();

        if (stopped)
        {
         
            foreach(var items in panelsDisactive)
            {
                items.SetActive(false);
            }

            foreach (var items in panelsActive)
            {
                items.SetActive(true);
            }
           
        }
        else
        {
            Time.timeScale = 1;
        }
       

        
        

 

        if (events.ispause)
        {
            Time.timeScale = 0;
        }

    }






}





