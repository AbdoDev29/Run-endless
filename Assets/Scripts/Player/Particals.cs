using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particals : MonoBehaviour
{
    [SerializeField] GameObject effectCoin;
    [SerializeField] Transform position;
   [SerializeField] float timerToDestroy_FX;
    GameObject FX;



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ("Coin"))
        {
           
            timerToDestroy_FX += Time.deltaTime;
             FX = Instantiate(effectCoin, position.position, Quaternion.identity);
            PlayerManager.coinScore1 += 1;
            PlayerManager.coinScore2 += 1;
            
            PlayerManager.totalScore += 1;
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            Destroy(other.gameObject);

        }

    }

}
       
         

