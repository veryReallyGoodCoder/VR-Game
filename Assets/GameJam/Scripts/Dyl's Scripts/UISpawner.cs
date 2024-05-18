using UnityEngine;
using UnityEngine.UI;

public class UISpawner : MonoBehaviour
{
    //  the UI element prefab 
    public GameObject uiElementPrefab;

    // Reference to the canvas 
    public Canvas canvas;

    // spawn  Method 
    public void SpawnUIElement()
    {
        // Check if the prefab and canvas are set
        if (uiElementPrefab != null && canvas != null)
        {
            // Instantiate the UI element prefab as a child of the canvas
            GameObject uiElement = Instantiate(uiElementPrefab, canvas.transform);

            // set the position, rotation, and scale of the spawned UI element 
            // uiElement.transform.position = ...
            // uiElement.transform.rotation = ...
            // uiElement.transform.localScale = ...
        }
        else
        {
            Debug.LogError("UI element prefab or canvas is not set!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the method to spawn the UI element
            SpawnUIElement();
        }
    }
}
