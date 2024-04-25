using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSpawner : MonoBehaviour
{
    [SerializeField] private Transform xrRigTransform; // Reference to the XRRig's transform
    [SerializeField] private GameObject tablePrefab;   // Reference to the table prefab
    [SerializeField] private float spawnDistance = 1f; // Distance from the XRRig to spawn the table
    //[SerializeField] private GameObject TablePosition;

    private GameObject currentTableInstance; // To keep track of the spawned table

    public void TableVisibilityToggle()
    {
        // Calculate the spawn position based on the XRRig's position and forward direction
        Vector3 spawnPosition = xrRigTransform.position + xrRigTransform.forward * spawnDistance;
        //Vector3 spawnPosition = TablePosition.transform.position;
        
        Debug.Log("Spawn Position: " + spawnPosition);
        
        // Check if a table already exists
        if (currentTableInstance != null)
        {
            // Option 1: Move the existing table
            currentTableInstance.transform.position = spawnPosition;

            // Option 2: Destroy and respawn (uncomment the following lines if you prefer this approach)
            // Destroy(currentTableInstance);
            // currentTableInstance = Instantiate(tablePrefab, spawnPosition, Quaternion.Euler(0f, 90f, 0f));
        }
        else
        {
            // Spawn the table at the calculated position with the desired rotation
            currentTableInstance = Instantiate(tablePrefab, spawnPosition, Quaternion.Euler(0f, 90f, 0f));
        }
    }
}