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

    public GameObject Barbells;
    private bool isHoldingBarbell = false;



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
        bool interactPressed = Input.GetKeyDown(KeyCode.T);
        bool backwardsPressed = Input.GetKey("s");
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool runPressed = Input.GetKey("left shift");


        bool moveRightPressed = Input.GetKey("d");
        bool moveLeftPressed = Input.GetKey("a");
        bool isRunning = animator.GetBool("isRunning");

        bool isSquatting = animator.GetBool("isWalkingBackwards");

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


        if (!isSquatting && interactPressed)
        {
            animator.SetBool("isSquatting", true);
            if (!isHoldingBarbell)
            {
                PickUpBarbell();  // Start the squat animation with barbell
            }
            else
            {
                DropBarbell();    // Optional: Drop or release the barbell
                animator.SetTrigger("idle");
            }
        }

        

        if (isSquatting && !interactPressed)
        {
            DropBarbell();
            animator.SetBool("isSquatting", false);
        }


    }

    void PickUpBarbell()
    {
        // Set the trigger in the Animator to start the squat animation
        animator.SetTrigger("squat");

        // Attach the barbell to the character's right hand (or both hands)
        Transform rightHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
        Transform leftHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand");

        if (rightHand != null && leftHand != null)
        {
            // Attach the barbell to the right hand (or a position between both hands)
            Barbells.transform.SetParent(rightHand);  // Optionally, you can use a midpoint between both hands

            // Adjust the local position and rotation to align the barbell with the hands
            Barbells.transform.localPosition = new Vector3(0f, 0.1f, 0.1f);  // Adjust based on the alignment of the hands
            Barbells.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);  // Adjust rotation to fit the barbell correctly

            // Optionally, you could calculate the midpoint between both hands and set the barbell there
            Vector3 handMidpoint = (rightHand.position + leftHand.position) / 2;
            Barbells.transform.position = handMidpoint;

            // Ensure the barbell follows the hand movement properly
            Debug.Log("Barbell picked up and aligned with hands.");
        }
        else
        {
            Debug.LogError("Hand(s) not found!");
        }

        isHoldingBarbell = true;  // Update state
        
    }


    void DropBarbell()
    {
        // Detach the barbell from the hand
        Barbells.transform.SetParent(null);  // Unparent the barbell from the hand

        // Optionally, set the position of the barbell near the player's feet or a specific location (floor position)
        Vector3 dropPosition = playerTrans.position + new Vector3(0f, -0.5f, 1f);  // Adjust as needed
        Barbells.transform.position = dropPosition;  // Set it just above the floor so gravity can pull it down

        // Enable physics for the barbell (gravity)
        Rigidbody rb = Barbells.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;  // Enable physics so the barbell can fall to the ground
            rb.useGravity = true;    // Ensure gravity is enabled
        }

        isHoldingBarbell = false;  // Update state
    }
}
