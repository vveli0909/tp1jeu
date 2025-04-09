using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveRandom : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] goals;  
    public NavMeshAgent agent;
    private Transform currentGoal;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Si la capsule a atteint le but actuel
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            SetNewDestination();
        }
    }
    void SetNewDestination()
    {
        if (goals.Length < 2) return;

        Transform newGoal;

        // Choisir un nouveau but différent du précédent
        do
        {
            newGoal = goals[Random.Range(0, goals.Length)];
        }
        while (newGoal == currentGoal);

        currentGoal = newGoal;
        agent.SetDestination(currentGoal.position);
    }
}
