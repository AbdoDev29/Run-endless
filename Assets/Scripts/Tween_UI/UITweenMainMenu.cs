using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject titleGame, startButton;

    private void Start()
    {
        LeanTween.scale(titleGame, new Vector3(0.47f, 0.47f, 0.47f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(Buttons);
        LeanTween.scale(titleGame, new Vector3(0.50f, 0.50f, 0.50f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
      //  LeanTween.moveLocal(titleGame, new Vector3(0f, 446f, 0f), .7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
    }
    private void Buttons()
    {
        LeanTween.scale(startButton, new Vector3(0.73f, 0.73f, 0.73f), 2f).setDelay(.9f).setEase(LeanTweenType.easeOutElastic);
    }
       
}
