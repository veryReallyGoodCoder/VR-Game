using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class navmeshPigModelScript : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player; 

    private void Update()
    {
        enemy.SetDestination(Player.position); 
    }
}