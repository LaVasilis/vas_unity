using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitScript : MonoBehaviour
{
    void Update()
    {
        // Check the F8 key
        if (Input.GetKeyDown(KeyCode.F8))
        {

            // This will close the game 
            Application.Quit();

            // Exit play mode if in the editor
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
