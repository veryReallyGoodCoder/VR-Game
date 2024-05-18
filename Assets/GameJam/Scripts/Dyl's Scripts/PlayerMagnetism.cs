using UnityEngine;

public class PlayerMagnetism : MonoBehaviour
{
    public float magnetForce = 10f; // Strength of the magnetism force

    [SerializeField] void FixedUpdate()
    {
        // Check if the player is connecting to objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f); // Adjust the radius as needed
        foreach (Collider collider in colliders)
        {
            // Check object has a Rigidbody and is not kinematic (i.e., it can move)
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb && !rb.isKinematic)
            {
                // Calculate the direction from the player to the object
                Vector3 direction = (collider.transform.position - transform.position).normalized;

                // Apply a force to attract the player towards the object
                rb.AddForce(-direction * magnetForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
    }
}
