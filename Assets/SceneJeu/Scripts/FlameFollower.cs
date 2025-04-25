using UnityEngine;
using UnityEngine.AI;

public class FlameFollower : MonoBehaviour
{
    public FlameManager flameManager;
    public NavMeshAgent agent;
    public GameObject currentTarget;

    protected void Start()
    {
        if (agent == null)
        { 
            agent = GetComponent<NavMeshAgent>();
        }
           
    }

    protected void Update()
    {
        if (agent == null || !agent.isOnNavMesh) return; 

        GameObject target = flameManager.currentGoal;

        if (target != null && target != currentTarget)
        {
            currentTarget = target;
            if (agent.isOnNavMesh)
                agent.SetDestination(currentTarget.transform.position);
        }

        if (currentTarget != null &&!agent.pathPending &&
           agent.remainingDistance <= agent.stoppingDistance &&
           (!agent.hasPath || agent.velocity.sqrMagnitude == 0f))
        {
            flameManager.GoalReached(currentTarget);
            currentTarget = null;
        }

    }
}
