using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToDeliver : MonoBehaviour
{
    public NavMeshAgent truckAgent; // Assigns the truck NavMeshAgent in the inspector

    void OnMouseDown()
    {
        if (truckAgent != null)
        {
            truckAgent.SetDestination(new Vector3(40, 6, 69));
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
