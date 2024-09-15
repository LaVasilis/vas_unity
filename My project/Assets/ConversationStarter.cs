using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Start the conversation
                ConversationManager.Instance.StartConversation(myConversation);

                // Unlock the cursor during conversation
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // Make the cursor visible

                Debug.Log("Conversation started");

                // Subscribe to the conversation end event
                ConversationManager.OnConversationEnded += OnConversationEnded;
            }
        }
    }

    private void OnConversationEnded()
    {
        // Lock the cursor again after the conversation ends
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Hide the cursor again

        Debug.Log("Conversation ended, cursor locked");

        // Unsubscribe to prevent memory leaks or duplicate events
        ConversationManager.OnConversationEnded -= OnConversationEnded;
    }
}
