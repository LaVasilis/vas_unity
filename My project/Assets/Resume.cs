using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PanelHelp;

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResumeFunction(){
        PanelHelp.SetActive(false);
        // Cursor.lockState = CursorLockMode.Locked; 

    }

}
