using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    [SerializeField] int position;
     Transform player;
    AudioManager audio_;
    PlayerController playerController;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audio_ = FindObjectOfType<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= 100f)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;

            // The car stops when it meets the player on the same road
            if (distance <= 7)
            {
                if (playerController.desiredLane == position)
                    speed = 0;
                else if (playerController.desiredLane == position)
                    speed = 0;
                else if (playerController.desiredLane == position)
                    speed = 0;
            }
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag != ("NonBeep"))
        {
            if (other.gameObject.tag == ("Player"))
            {
                audio_.PlaySound("Car");
            }
        }
  
       
    }

}
       

