using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UITweenFinishGame : MonoBehaviour
{
    [SerializeField] private GameObject backPanel, shopButton, replayButton,score, star1, star2, star3;
 
    void Start()
    {

        LeanTween.moveLocal(backPanel, new Vector3(-13f, 6f, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc).setOnComplete(StarsAnim);
        LeanTween.scale(replayButton, new Vector3(2.8f, 2.5f, 1f), 2f).setDelay(.9f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(shopButton, new Vector3(2.8f, 2.5f, 1f), 3f).setDelay(.8f).setEase(LeanTweenType.easeOutElastic);

    }



    void StarsAnim()
    {
        LeanTween.scale(star1, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(1.5f, 1.5f, 1.5f), 2f).setDelay(.1f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star3, new Vector3(1f, 1f, 1f), 2f).setDelay(.2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(score, new Vector3(1f, 1f, 1f), 2f).setEase(LeanTweenType.easeOutElastic);
    }
}
