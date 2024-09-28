using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject PanelHelp;

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape)){

            Cursor.lockState = CursorLockMode.None; 
            PanelHelp.SetActive(true);
    }
    }
}
