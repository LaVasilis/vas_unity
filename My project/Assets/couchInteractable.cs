using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couchInteractable : MonoBehaviour
{
     public GameObject Panel;
    
    public void Interact(){
        Panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None; 
        Debug.Log("Quiz");

    }



}
