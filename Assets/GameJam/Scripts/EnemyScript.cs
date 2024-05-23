using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform player;

    [SerializeField] private float speed;
    [SerializeField] private float distToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance from pig to player
        distToPlayer = Vector3.Distance(transform.position, player.position);

        if(distToPlayer >= 0.1)
        {
            agent.destination = player.position;
            //Debug.Log("Chasing Player");
        }
        else
        {
            agent.SetDestination(transform.position);
        }

    }
}
