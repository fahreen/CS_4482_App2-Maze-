using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnimator;
    int isWalkingHash;
    //public CharacterController controller;
    
    public float speed = 6f;
    public float rotSpeed  = 80;


    //rigidbody
    private Rigidbody m_Rb;
    private float m_SpeedModifier =1;


    // Start is called before the first frame update
    void Start()
    {
        

        playerAnimator = GetComponent<Animator>();
       
        isWalkingHash = Animator.StringToHash("isWalking");
        //controller.center = new Vector3(0, 1, 0);

        //rigidbody
        m_Rb = GetComponent<Rigidbody>();
    }



    

    // Update is called once per frame
    void FixedUpdate()
    {

            //player movement
            //get player input
            float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving;

        Vector3 playerPos = m_Rb.position;
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement).normalized;

       


        if (movement.magnitude >= 0.1f)
        {
             isMoving = true;


            //move with rigid body
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

            m_Rb.MovePosition(playerPos + movement * m_SpeedModifier * speed * Time.fixedDeltaTime);
            m_Rb.MoveRotation(targetRotation);

        }
        else
        {
            isMoving = false;
        }



        //animation
        bool isPlayingWalkAnimation = playerAnimator.GetBool(isWalkingHash);
        
        bool forwardPressed = Input.GetKey("q");

        if (!isPlayingWalkAnimation &&  isMoving)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (isPlayingWalkAnimation && !isMoving)
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }
}
