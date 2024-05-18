using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] positions;   // Array of positions 
    public float[] moveTimes;       // Array of times 
    public float waitTime = 1f;     // Time before moving to the next position
    private int currentPositionIndex = 0;

    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            // Move  next position
            yield return StartCoroutine(MoveToPosition(positions[currentPositionIndex], moveTimes[currentPositionIndex]));

            // Increment  index or loop beginning
            currentPositionIndex = (currentPositionIndex + 1) % positions.Length;

            // Wait before moving to the next position
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveToPosition(Transform target, float time)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = target.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos; // Ensure platform reaches the position
    }
}