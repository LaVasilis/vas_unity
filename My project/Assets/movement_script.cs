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
    public GameObject Treadmill;
    public GameObject matt;
    public GameObject matt2;

    public GameObject Dumbell_1;
    public GameObject Dumbell_2;
    public GameObject sumoObj;
    public GameObject Bicycle;
    public couchInteractable couch;



    private bool isHoldingBarbell = false;
    private bool isNearBarbell = false;


    private bool isHoldingsumoObj = false;
    private bool isNearsumoObj = false;

    

    private bool isOnTreadmill = false;
    private bool isNearTreadmill = false;


    private bool isHoldingDumbell = false;
    private bool isNearDumbell = false;

    private bool isOnMatt = false;
    private bool isNearMatt = false;

    private bool isOnMatt2 = false;
    private bool isNearMatt2 = false;

    private bool isOnBicycle = false;
    private bool isNearBicycle = false;

    public float interactionDistance = 2f;  // Distance within which the player can interact with the barbell and treadmill

    

    void Start()
    {
        
        
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

        if (isOnTreadmill)
        {
            // Simulate the player moving on the treadmill
            playerTrans.position = new Vector3(-53.08f, 5.037203f, -20.96f);
            playerTrans.rotation = Quaternion.Euler(0f, -178.012f, 0f);
        }

        if (isOnMatt)
        {
            // Simulate the player moving on the treadmill
            playerTrans.position = new Vector3(-34.93f, 5.037203f, -14.75164f);
            playerTrans.rotation = Quaternion.Euler(0f, -178.012f, 0f);
        }

        if (isOnMatt2)
        {
            // Simulate the player moving on the treadmill
            playerTrans.position = new Vector3(-31.147f, 5.037203f, -13.656f);
            playerTrans.rotation = Quaternion.Euler(0f, -178.012f, 0f);
        }

        if (isOnBicycle)
        {
            
            playerTrans.position = new Vector3(-46.73f, 5.135f, -20.017f);
            playerTrans.rotation = Quaternion.Euler(0f, -178.012f, 0f);
        }
    }

    
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool cPressed = Input.GetKey("c");
        bool interactPressed = Input.GetKeyDown(KeyCode.T);
        bool backwardsPressed = Input.GetKey("s");
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBackwards = animator.GetBool("isWalkingBackwards");
        bool runPressed = Input.GetKey("left shift");
        Cursor.lockState = CursorLockMode.None;

        bool moveRightPressed = Input.GetKey("d");
        bool moveLeftPressed = Input.GetKey("a");
        bool isRunning = animator.GetBool("isRunning");

        bool isSquatting = animator.GetBool("isWalkingBackwards");

        bool isCurling = animator.GetBool("isCurling");

        bool treadmill = animator.GetBool("treadmill");

        bool isJumping = animator.GetBool("isJumping");

        bool isPlanking = animator.GetBool("isPlanking");

        
        bool isSumo = animator.GetBool("isSumo");
        bool isCycling = animator.GetBool("isCycling");

        // Check if the player is near the barbell
        float distanceToBarbell = Vector3.Distance(playerTrans.position, Barbells.transform.position);
        isNearBarbell = distanceToBarbell <= interactionDistance;

        // Check if the player is near the treadmill
        float distanceToTreadmill = Vector3.Distance(playerTrans.position, Treadmill.transform.position);
        isNearTreadmill = distanceToTreadmill <= interactionDistance;

        // Check if the player is near the treadmill
        float distanceToDumbell = Vector3.Distance(playerTrans.position, Dumbell_1.transform.position);
        isNearDumbell = distanceToDumbell <= interactionDistance;

        float distanceToMatt = Vector3.Distance(playerTrans.position, matt.transform.position);
        isNearMatt = distanceToMatt <= interactionDistance;


        float distanceToMatt2 = Vector3.Distance(playerTrans.position, matt2.transform.position);
        isNearMatt2 = distanceToMatt2 <= interactionDistance;


        float distanceToSumoObj = Vector3.Distance(playerTrans.position, sumoObj.transform.position);
        isNearsumoObj = distanceToSumoObj <= interactionDistance;

        float distanceToBicycle = Vector3.Distance(playerTrans.position, Bicycle.transform.position);
        isNearBicycle = distanceToBicycle <= interactionDistance;

        


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

       
        if (!isSquatting && interactPressed && isNearBarbell && !isHoldingBarbell)
        {
            animator.SetBool("isRunning", false);
            PickUpBarbell();  
        }

        if (isSquatting && (interactPressed || forwardPressed || backwardsPressed) && isHoldingBarbell)
        {
            DropBarbell();    
        }


        if (!isCurling && interactPressed && !isHoldingDumbell && isNearDumbell)
        {
            
            PickUpDumbell(); 
        }

        if (isCurling && (interactPressed || forwardPressed || backwardsPressed) && isHoldingDumbell)
        {
            DropDumbell();    
        }

     


        if (!isSumo && interactPressed && !isHoldingsumoObj && isNearsumoObj)
        {

            PickUpSumoObj();  
        }

        if (isSumo && (interactPressed || forwardPressed || backwardsPressed) && isHoldingsumoObj)
        {
            DropSumoObj();    
        }

        if (!isJumping && interactPressed && isNearMatt)
        {
            // Trigger the treadmill animation
            animator.SetBool("isJumping", true);

            isOnMatt = true; // Set player on treadmill
          
        }

        if (isJumping && (interactPressed || forwardPressed || backwardsPressed) && isOnMatt)
        {
            // Stop the treadmill animation if T is pressed again
            animator.SetBool("isJumping", false);
            isOnMatt = false;
            playerTrans.position = new Vector3(-34.93f, 4.9f, -12.947f);
           
        }

        if (!isPlanking && interactPressed && isNearMatt2)
        {
            // Trigger the treadmill animation
            animator.SetBool("isPlanking", true);

            isOnMatt2 = true; // Set player on treadmill
          
        }

        if (isPlanking && (interactPressed || forwardPressed || backwardsPressed) && isOnMatt2)
        {
            // Stop the treadmill animation if T is pressed again
            animator.SetBool("isPlanking", false);
            isOnMatt2 = false;
            playerTrans.position = new Vector3(-31.147f, 4.9f, -12.614f);
           
        }




        if (!treadmill && interactPressed && isNearTreadmill)
        {
            // Trigger the treadmill animation
            animator.SetBool("treadmill", true);
           
            isOnTreadmill = true; // Set player on treadmill
            
        }

        if (treadmill && (interactPressed || forwardPressed || backwardsPressed) && isOnTreadmill)
        {
            // Stop the treadmill animation if T is pressed again
            animator.SetBool("treadmill", false);
            isOnTreadmill = false;
            playerTrans.position = new Vector3(-52.6663f, 4.9f, -19.6006f);
           
        }


        if (!isCycling && interactPressed && isNearBicycle)
        {
            // Trigger the treadmill animation
            animator.SetBool("isCycling", true);

            isOnBicycle = true; // Set player on treadmill
            
        }

        if (isCycling && (interactPressed || forwardPressed || backwardsPressed) && isOnBicycle)
        {
            // Stop the treadmill animation if T is pressed again
            animator.SetBool("isCycling", false);
            isOnBicycle = false;
            playerTrans.position = new Vector3(-46.73f, 4.9f, -18.87f);
            
        }




    }


    


    void PickUpSumoObj()
    {
        // Set the trigger in the Animator to start the squat animation
        animator.SetBool("isSumo", true);

        // Attach the barbell to the character's right hand (or both hands)
        Transform rightHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
        

        if (rightHand != null)
        {
            sumoObj.transform.SetParent(rightHand);
            sumoObj.transform.localPosition = new Vector3(-0.0737501f, -0.00000000000001f, -0.04f);
            sumoObj.transform.localRotation = Quaternion.Euler(180f, 0f, 0f);
        }
        else
        {
            Debug.LogError("Hand(s) not found!");
        }

        isHoldingsumoObj = true;
        //interactionText.enabled = false; // Hide the popup after picking up the barbell
    }


    void DropSumoObj()
    {
        animator.SetBool("isSumo", false);
        sumoObj.transform.SetParent(null);

        Vector3 dropPosition = playerTrans.position + new Vector3(0f, -0.75f, -1f);
        sumoObj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        sumoObj.transform.position = dropPosition;


        

        Rigidbody rb1 = sumoObj.GetComponent<Rigidbody>();
       
        if (rb1 != null)
        {
            rb1.isKinematic = false;
            rb1.useGravity = true;

           
        }


        isHoldingsumoObj = false;
    }

    void PickUpDumbell()
    {
        // Set the trigger in the Animator to start the squat animation
        animator.SetBool("isCurling", true);

        // Attach the barbell to the character's right hand (or both hands)
        Transform rightHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
        Transform leftHand = transform.Find("player_model/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand");

        if (rightHand != null && leftHand != null)
        {
            Dumbell_1.transform.SetParent(rightHand);
            Dumbell_1.transform.localPosition = new Vector3(-0.0737501f, -0.004394529f, -0.04f);
            Dumbell_1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            
            Dumbell_2.transform.SetParent(leftHand);
            Dumbell_2.transform.localPosition = new Vector3(-0.0737501f, -0.004394529f, 0.04f);
            Dumbell_2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            Debug.LogError("Hand(s) not found!");
        }

        isHoldingDumbell = true;
        //interactionText.enabled = false; // Hide the popup after picking up the barbell
    }


    void DropDumbell()
    {
        animator.SetBool("isCurling", false);
        Dumbell_1.transform.SetParent(null);
        Dumbell_2.transform.SetParent(null);

        Vector3 dropPosition = playerTrans.position + new Vector3(0f, -0.5f, -1f);
        Dumbell_1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Dumbell_1.transform.position = dropPosition;


        Vector3 dropPosition2 = playerTrans.position + new Vector3(0.6f, -0.5f, -1f);
        Dumbell_2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Dumbell_2.transform.position = dropPosition2;

        Rigidbody rb1 = Dumbell_1.GetComponent<Rigidbody>();
        Rigidbody rb2 = Dumbell_2.GetComponent<Rigidbody>();
        if (rb1 != null && rb2 != null)
        {
            rb1.isKinematic = false;
            rb1.useGravity = true;

            rb2.isKinematic = false;
            rb2.useGravity = true;
        }


        isHoldingDumbell = false;
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
            Barbells.transform.localPosition = new Vector3(-0.3737501f, -0.05394529f, 0.1f);
            Barbells.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            Debug.LogError("Hand(s) not found!");
        }

        isHoldingBarbell = true;
        //interactionText.enabled = false; // Hide the popup after picking up the barbell
    }

    void DropBarbell()
    {
        animator.SetBool("isSquatting", false);
        Barbells.transform.SetParent(null);

        Vector3 dropPosition = playerTrans.position + new Vector3(0f, -0.5f, -1f);
        Barbells.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
