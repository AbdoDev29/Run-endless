using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Variables
    [SerializeField] private float speedrotation;
    [SerializeField] string coinNam = "default";
    [SerializeField]Transform mainCameraTransform;


    private void Start()
    {
        if (coinNam != "default")
            transform.LookAt(mainCameraTransform);
    }
    void Update()
    {
        transform.Rotate(0, speedrotation * Time.deltaTime, 0);
      
    }

 
}
