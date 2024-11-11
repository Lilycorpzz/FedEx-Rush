using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceTrackers : MonoBehaviour
{

    public TMP_Text DistanceText;
    private Vector3 startPosition;
    private float totalDistance = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        totalDistance = Vector3.Distance(startPosition, transform.position);

        DistanceText.text = "Distance : " + totalDistance.ToString("F2") + "m";
    }
}
