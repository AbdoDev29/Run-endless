using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // references
    private CharacterController controller;
    private Animator anim;
    PlayerManager playerManager;
    Events events;
    // variables
    public float moveSpeed;
   
    
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float Gravity;

   public bool isHitByObstacl = false;
    public bool isPlay = false;
    public bool isWatchAd = false;



    private float inputX; // left and right
    private Vector3 moveDirection;
    private bool isSliding = false;
    public int desiredLane = 1; //0: left 1:middle 2:right
    [SerializeField] private float laneDistance = 6; // the distance between two lanes
    [SerializeField]private GameObject UITween;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        playerManager = FindObjectOfType<PlayerManager>();
        events = FindObjectOfType<Events>();
    }
    private void Start()
    {
        isWatchAd = false;
    }

    private void Update()
    {
       

     
        // Increase speed
        if (moveSpeed < maxSpeed && !events.isDied)
            moveSpeed += 0.1f * Time.deltaTime;
        if(!isHitByObstacl)
        Move();

        NewThePath();

        // Jump
        if (controller.isGrounded) // if the player isGrounded he gonna active the gravity and jump animation is false
        {

            anim.SetBool("Jump", false);
            moveDirection.y = -1;
            if (!playerManager.panelContinue.activeSelf)
            {

                if (SwipeManager.swipeUp)
                {
                    anim.SetBool("Jump", true);
                    Jump();
                }
            }

        }
        else
        {
            moveDirection.y -= Gravity * Time.deltaTime;

        }
        // Controll as animatipon slide and CharacterController
        if (SwipeManager.swipeDown)
        {
            if (controller.isGrounded)
                StartCoroutine(Slide());
            else
                moveDirection.y = -10f;
        }

    }

    public void Move()
    {
        inputX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(0, moveDirection.y, moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
        anim.SetBool("Run", true);
    }

    private void Jump()
    {
        moveDirection.y = jumpForce;
    }



    // Selecting the path
    private void NewThePath()
    {
        if (!playerManager.panelContinue.activeSelf)
        {
            if (SwipeManager.swipeRight)
            {

                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }


            if (SwipeManager.swipeLeft)
            {

                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }
        }


        // calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80f * Time.deltaTime);
    }







    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.transform.tag == ("Obstacle"))
        {


            if (!isWatchAd)
            {
                playerManager.panelContinue.SetActive(true);
            }
            // Destroy the obstacle if the user watched Ad;
            else
            {
               
                Destroy(hit.gameObject);
                playerManager.panelContinue.SetActive(false);

            }
        }
        isWatchAd = false;


               
                     

               

      

        if (hit.transform.tag == ("Water"))
        {
            PlayerManager.stopped = true;
        }
    }
          



    private IEnumerator Slide()
    {
        // If swipe down
        anim.SetBool("Slide", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        // If swipe up
        yield return new WaitForSeconds(1.3f);
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        anim.SetBool("Slide", false);
    }
  
}




