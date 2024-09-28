using UnityEngine;

public class uiScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject summary_canvas; // Drag your canvas object here in the Inspector
    public KeyCode toggleKey = KeyCode.Alpha1;
    public KeyCode toggleKeyForSummary = KeyCode.Alpha2; // The key that will toggle the canvas visibility
    public MonoBehaviour playerMovement;

    void Start()
    {
        canvas.SetActive(false);
        summary_canvas.SetActive(false);
        playerMovement.enabled = true;
    }

    void Update()
    {
        // Check if the player presses the toggle key (default: E)
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

        // Disable player movement when the canvas is active
        playerMovement.enabled = !isCanvasActive;
    }

    void ToggleSummaryCanvas()
    {
        bool isSummaryCanvasActive = !summary_canvas.activeSelf;
        summary_canvas.SetActive(isSummaryCanvasActive);

        // Disable player movement when the summary canvas is active
        playerMovement.enabled = !isSummaryCanvasActive;
    }
}
