using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSpawn : MonoBehaviour //Rigidbody is also required to check for collisions
{
    public GameObject objectToSpawn; // Assign prefab in Editor
    public Vector3 spawnPositionOffset; // Offset from the trigger's position where the object will be spawned
    public AudioClip spawnSound; //  play 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object is tagged as "Player"
        {
            SpawnObject(); // call to spawn object
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Vector3 spawnPosition = transform.position + spawnPositionOffset; // Calculate  spawn position
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); // Spawn  object at the  position
            
            // Play sound + AudioSource component on the spawned object
            if (spawnSound != null && spawnedObject.GetComponent<AudioSource>() != null)
            {
                spawnedObject.GetComponent<AudioSource>().PlayOneShot(spawnSound);
            }
        }
        else
        {
            Debug.LogWarning("Object to spawn is not assigned!");
        }
    }
}
