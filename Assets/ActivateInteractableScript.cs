using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInteractableScript : MonoBehaviour
{
    public Color touchHighlightColor;

    private void OnTriggerEnter(Collider other)
    {
        // Get Renderer component
        var renderer = other.GetComponent<Renderer>();

        // If the touched object has a Renderer Component
        if (renderer != null)
        {
            // Get TouchObjectData component
            var touchObjectData = other.GetComponent<TouchObjectData>();

            // If the object does not have a TouchDataObject component
            // (Meaning: If this object hasn't been handled yet)
            if (touchObjectData == null)
            {
                // Add a new TouchObjectData component to the touched object
                touchObjectData = other.gameObject.AddComponent<TouchObjectData>();

                // Save the Original Color on the new component
                touchObjectData.originalColor = renderer.material.color;

                // Highlight Object
                renderer.material.color = touchHighlightColor;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Get Renderer component
        var renderer = other.GetComponent<Renderer>();

        // If the touched object has a Renderer Component
        if (renderer != null)
        {
            // Get TouchObjectData component
            var touchObjectData = other.GetComponent<TouchObjectData>();

            // If the object has a TouchDataObject component
            if (touchObjectData != null)
            {
                // Restore the Original Color
                renderer.material.color = touchObjectData.originalColor;

                // Remove the TouchObjectData component
                Object.Destroy(touchObjectData);
            }
        }
    }
}
