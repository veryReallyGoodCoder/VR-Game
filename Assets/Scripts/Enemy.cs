using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float speed = 2f;
    private NavMeshAgent agent;
    private bool inMolotov = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inMolotov == false)
        {
            agent.SetDestination(player.position);
            agent.speed = speed;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        speed = 2f;
        inMolotov = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Molotov"))
        {
            inMolotov = true;
            Debug.Log("triggered");
            agent.speed = 0f;
            StartCoroutine(Delay());
        }
    }
}
