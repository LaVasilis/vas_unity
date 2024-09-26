using UnityEngine;

public class uiScript : MonoBehaviour
{
    public GameObject canvas;  // Drag your canvas object here in the Inspector
    public KeyCode toggleKey = KeyCode.E;  // The key that will toggle the canvas visibility
    public MonoBehaviour playerMovement;

    void Start()
    {
        canvas.SetActive(false);
        playerMovement.enabled = true;
    }

    void Update()
    {
        // Check if the player presses the toggle key (default: E)
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
        }
    }

    void ToggleCanvas()
    {
       
        bool isCanvasActive = !canvas.activeSelf;
        canvas.SetActive(isCanvasActive);

        
        playerMovement.enabled = !isCanvasActive;
    }
}
