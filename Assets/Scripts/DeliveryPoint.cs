using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeliveryPoint : MonoBehaviour
{
    public int points = 5; // Points awarded for a successful delivery
    private bool isDelivered = false; // Track if this point has been delivered
    private float deliveryTime = 0f;
    public Color deliveredColor = Color.green; // Color to indicate delivery
    private Renderer renderer;
    public GameObject FloatingTextPrefab;

    private void Start()
    {
        // Get the Renderer component for visual feedback
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Set initial color to indicate it's ready for delivery
            renderer.material.color = Color.red;
        }
    }

    private void OnMouseDown()
    {
        // This method is called when this specific GameObject is clicked
        if (!isDelivered)
        {
            DeliverPackage();
            
        }
    }

    private void DeliverPackage()
    {
        // Award points to the player
        GameManager.Instance.AddPoints(points);

        // Mark as delivered and capture the delivery time
        isDelivered = true;
        deliveryTime = Time.time;

        // Change color to indicate delivery status
        if (renderer != null)
        {
            renderer.material.color = deliveredColor;
        }

        // Optionally, trigger an effect or sound here
        Debug.Log("Package Delivered! Points awarded: " + points + " at time: " + deliveryTime);

        // Show floating text, if prefab is set
        ShowFloatingText();
    }

    private void ShowFloatingText()
    {
        if (FloatingTextPrefab)
        {
            Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    public void ResetDelivery()
    {
        // Reset delivery status and delivery time
        isDelivered = false;
        deliveryTime = 0f;

        // Reset color or appearance
        if (renderer != null)
        {
            renderer.material.color = Color.red; // Set back to initial color
        }

        Debug.Log("Delivery point has been reset.");
    }
}
