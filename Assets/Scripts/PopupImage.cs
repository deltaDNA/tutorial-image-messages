using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;

public class PopupImage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public void EngageCall(string decisionPoint)
    {

        DDNA.Instance.EngageFactory.RequestImageMessage(decisionPoint, null, (imageMessage) =>
        {

            // Check we got an engagement with a valid Privacy Policy image message.
            if (imageMessage != null)
            {
                Debug.Log("Engage returned a valid privacy policy image message.");

                // Show the image as soon as the background and button images have been downloaded.
                imageMessage.OnDidReceiveResources += () =>
                {
                    Debug.Log("Image Message loaded resources.");
                    imageMessage.Show();
                };

                // Add a handler for the 'dismiss' action.
                imageMessage.OnDismiss += (ImageMessage.EventArgs obj) =>
                {
                    Debug.Log("Image Message dismissed by " + obj.ID);
                  
                };

                // Add a handler for the 'action' action.
                imageMessage.OnAction += (ImageMessage.EventArgs obj) =>
                {
                    Debug.Log("Image Message actioned by " + obj.ID + " with command " + obj.ActionValue);
                };

                // Download the image message resources.
                imageMessage.FetchResources();
                DestroyPopupImageObject();
            }
            else
            {
                Debug.Log("Engage didn't return an image message.");
                //DestroyPopupImageObject();
            }
        });
        
    }

    private void DestroyPopupImageObject()
    {
        // Destroy the privacy policy object.
        if (gameObject != null)
        {
            Debug.Log("Destroying Image Popup");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
