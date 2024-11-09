using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    public int points = 5; // Points awarded for a successful delivery
    private bool isDelivered = false;
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

    private void Update()
    {
        // Detect if the player clicks the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            CheckForDelivery();

        }
    }

    private void CheckForDelivery()
    {
        // Raycast from the camera to detect the clicked object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check if the clicked object has the "DeliveryPoint" tag
            if (hit.collider.CompareTag("DeliveryPoint") && !isDelivered)
            {
                DeliverPackage();

                ShowFloatingText();
            }
        }
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
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

        
    }

    void ShowFloatingText()
    {
        Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
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
