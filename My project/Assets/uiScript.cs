using UnityEngine;

public class uiScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject summary_canvas; 
    public KeyCode toggleKey = KeyCode.Alpha1;
    public KeyCode toggleKeyForSummary = KeyCode.Alpha2; 
    public MonoBehaviour playerMovement;

    void Start()
    {
        canvas.SetActive(false);
        summary_canvas.SetActive(false);
        playerMovement.enabled = true;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
        }
        if (Input.GetKeyDown(toggleKeyForSummary))
        {
            ToggleSummaryCanvas();
        }
    }

    void ToggleCanvas()
    {
        bool isCanvasActive = !canvas.activeSelf;
        canvas.SetActive(isCanvasActive);

        
        playerMovement.enabled = !isCanvasActive;
    }

    void ToggleSummaryCanvas()
    {
        bool isSummaryCanvasActive = !summary_canvas.activeSelf;
        summary_canvas.SetActive(isSummaryCanvasActive);

        
        playerMovement.enabled = !isSummaryCanvasActive;
    }


}
