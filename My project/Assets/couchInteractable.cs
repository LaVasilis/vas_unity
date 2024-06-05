using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couchInteractable : MonoBehaviour
{
     public GameObject Panel;
    
    public void Interact(){
        Panel.SetActive(true);
        Debug.Log("Quiz");

    }



}
