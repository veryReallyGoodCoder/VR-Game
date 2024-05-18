using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform player;

    [SerializeField] private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
