using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnContact : MonoBehaviour
{
    //  scene to load
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Load scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
