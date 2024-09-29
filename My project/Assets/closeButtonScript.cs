using UnityEngine;

public class closeButtonScript : MonoBehaviour
{
    public GameObject UICANVAS;

    
    public void CloseUI()
    {


        UICANVAS.SetActive(false);

    }   
}
