using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;
    public couchInteractable couch;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;
    

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    
    void Update()
    {   
        

        
       if ( !EventSystem.current.IsPointerOverGameObject())
        {
            // Allow rotation if not interacting with UI
            
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
        }

       
        
    }

     void LateUpdate() {
       
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 e = head.eulerAngles;
            e.x -= Input.GetAxis("Mouse Y") * 2f;
            e.x = RestrictAngle(e.x, -85f, 85f);
            head.eulerAngles = e;
        }
    }


    void FixedUpdate(){

        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = transform.TransformDirection(newVelocity);


    }


     public static float RestrictAngle(float angle, float angleMin, float angleMax) {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }


    private bool isMouseOverUI(){
        return EventSystem.current.IsPointerOverGameObject();

    }


}
