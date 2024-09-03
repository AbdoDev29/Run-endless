using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecCharactar : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] int currentCarIndex;
    void Start()
    {
        currentCarIndex = PlayerPrefs.GetInt("CurrentCharacter", 0);
        foreach (GameObject car in cars)
            car.SetActive(false);

        cars[currentCarIndex].SetActive(true);
    }
}
