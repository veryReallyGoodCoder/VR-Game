using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class EnemyVThree : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float health = 1;
    private NavMeshAgent agent;
    private bool inMolotov = false;
    [SerializeField] public bool nextWave = false;
    SpawnPoint spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawnPoint = GameObject.Find("Spawn").GetComponent<SpawnPoint>();
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

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            StartCoroutine(KillEnemy());
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

        if (other.gameObject.CompareTag("Weapon"))
        {
            health--;
        }
    }

    IEnumerator KillEnemy()
    {
        spawnPoint.enemiesKilled++;
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
