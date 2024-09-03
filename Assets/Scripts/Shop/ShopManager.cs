using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject[] carModels;
    [SerializeField] int currentCarIndex;

    public CharacterBlueprint[] characterBlueprint;
    public Button buyButton;
    void Start()
    {
        foreach(CharacterBlueprint character in characterBlueprint)
        {
            if (character.price == 0)
                character.isUnlocked = true;
            else
                character.isUnlocked = PlayerPrefs.GetInt(character.name, 0) == 0 ? false : true;
        }

        currentCarIndex = PlayerPrefs.GetInt("CurrentCharacter", 0);
        foreach (GameObject car in carModels)
            car.SetActive(false);

        carModels[currentCarIndex].SetActive(true);
    }
    private void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex++;

        if (currentCarIndex == carModels.Length)
            currentCarIndex = 0;

        carModels[currentCarIndex].SetActive(true);
        CharacterBlueprint c = characterBlueprint[currentCarIndex];
        if (!c.isUnlocked)
            return;

        PlayerPrefs.SetInt("CurrentCharacter", currentCarIndex);
    }
    public void ChangePrevious()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex--;

        if (currentCarIndex == -1)
            currentCarIndex = carModels.Length -1;

        carModels[currentCarIndex].SetActive(true);

        CharacterBlueprint c = characterBlueprint[currentCarIndex];
        if (!c.isUnlocked)
            return;

        PlayerPrefs.SetInt("CurrentCharacter", currentCarIndex);
    }
    int currentScore;

    public void UnloackCharacter()
    {
        CharacterBlueprint c = characterBlueprint[currentCarIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("CurrentCharacter", currentCarIndex);
        c.isUnlocked = true;

        PlayerManager.totalScore -= c.price;
        PlayerPrefs.SetInt("score", PlayerManager.totalScore);

     

    }
    private void UpdateUI()
    {
        CharacterBlueprint c = characterBlueprint[currentCarIndex];
        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + c.price;

            if (c.price >= PlayerPrefs.GetInt("score", 0)) 
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }

        }

    }
}
