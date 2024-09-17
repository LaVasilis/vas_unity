using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to access UI elements

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
    private bool isNearBarbell = false;
    public float interactionDistance = 2f;  // Distance within which the player can interact with the barbell

    public Text interactionText; // Reference to the UI Text

    void Start()
    {
        // Make sure the interaction text is initially hidden
        interactionText.enabled = false;
    }

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

        
        // Check if the player is near the barbell
        float distanceToBarbell = Vector3.Distance(playerTrans.position, Barbells.transform.position);
        isNearBarbell = distanceToBarbell <= interactionDistance;

        // Show the interaction text if the player is near the barbell, otherwise hide it
        if (isNearBarbell && !isHoldingBarbell)
        {
            interactionText.enabled = true; // Show "Press T" popup
        }
        else
        {
            interactionText.enabled = false; // Hide the popup
        }

        if (!isWalking && forwardPressed)
        {
            Walking_speed = Olw_speed;
            animator.SetBool("isWalking", true);
            if (isHoldingBarbell)
            {
                DropBarbell();
            }
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

        // Check if the player is near the barbell and presses T
        if (!isSquatting && interactPressed && isNearBarbell)
        {
            animator.SetBool("isRunning", false);
            PickUpBarbell();  // Start the squat animation with barbell
        }

        if (isSquatting && backwardsPressed && isHoldingBarbell)
        {
            DropBarbell();    // Optional: Drop or release the barbell
        }
    }

    void PickUpBarbell()
    {
        // Set the trigger in the Animator to start the squat animation
        animator.SetBool("isSquatting", true);

        // Attach the barbell to the character's right hand (or both hands)
        Transform rightHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
        Transform leftHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand");

        if (rightHand != null && leftHand != null)
        {
            Barbells.transform.SetParent(rightHand);
            Barbells.transform.localPosition = new Vector3(0f, 0.1f, 0.1f);
            Barbells.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            Vector3 handMidpoint = (rightHand.position + leftHand.position);
            Barbells.transform.position = handMidpoint;
        }
        else
        {
            Debug.LogError("Hand(s) not found!");
        }

        isHoldingBarbell = true;
        interactionText.enabled = false; // Hide the popup after picking up the barbell
    }

    void DropBarbell()
    {
        animator.SetBool("isSquatting", false);
        Barbells.transform.SetParent(null);

        Vector3 dropPosition = playerTrans.position + new Vector3(0f, -0.5f, 1f);
        Barbells.transform.position = dropPosition;

        Rigidbody rb = Barbells.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        isHoldingBarbell = false;
    }
}
