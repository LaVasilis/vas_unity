using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_script : MonoBehaviour
{
    public Animator animator;
    public Rigidbody playerRigid;
    public float Walking_speed = 120f;
    public float Jogback_speed = 120f;
    public float Olw_speed = 270f;
    public float Running_speed = 170f;
    public float Rotation_speed = 130f;

    public Transform playerTrans;



    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * Walking_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * Jogback_speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool backwardsPressed = Input.GetKey("s");
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool runPressed = Input.GetKey("left shift");


        bool moveRightPressed = Input.GetKey("d");
        bool moveLeftPressed = Input.GetKey("a");
        bool isRunning = animator.GetBool("isRunning");

        if (!isWalking && forwardPressed)
        {

            Walking_speed = Olw_speed;

            animator.SetBool("isWalking", true);
        }

        if (isWalking && !forwardPressed)
        {

            animator.SetBool("isWalking", false);
        }

        if (!isWalkingBackwards && backwardsPressed)
        {
            Jogback_speed = Olw_speed;
            animator.SetBool("isWalkingBackwards", true);
        }

        if (isWalkingBackwards && !backwardsPressed)
        {
            animator.SetBool("isWalkingBackwards", false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {

            Walking_speed = Walking_speed + Running_speed;
            Debug.Log(Walking_speed);
            animator.SetBool("isRunning", true);

        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            Walking_speed = Olw_speed;
            animator.SetBool("isRunning", false);

        }

        if (moveLeftPressed && forwardPressed)
        {
            playerTrans.Rotate(0, -Rotation_speed * Time.deltaTime, 0);
        }

        if (moveRightPressed && forwardPressed)
        {
            playerTrans.Rotate(0, Rotation_speed * Time.deltaTime, 0);
        }


        if (moveLeftPressed && backwardsPressed)
        {
            playerTrans.Rotate(0, -Rotation_speed * Time.deltaTime, 0);
        }

        if (moveRightPressed && backwardsPressed)
        {
            playerTrans.Rotate(0, Rotation_speed * Time.deltaTime, 0);
        }



    }
}
