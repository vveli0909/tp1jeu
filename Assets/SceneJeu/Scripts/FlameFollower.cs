using UnityEngine;
using UnityEngine.AI;

public class FlameFollower : MonoBehaviour
{
    public FlameManager flameManager;
    public NavMeshAgent agent;
    public GameObject currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GameObject target = flameManager.currentGoal;

        // Si le but a changé, on le poursuit
        if (target != null && target != currentTarget)
        {
            currentTarget = target;
            agent.SetDestination(currentTarget.transform.position);
        }
    }
}
