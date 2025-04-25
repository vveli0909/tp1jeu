

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FlameFollower
{
    public Animator animator;

    public float walkDistanceStart = 6f;     
    public float walkThreshold = 1.2f;       
    public float runThreshold = 2.5f;        
    private bool isAtGoal = false;
    protected  void Start()
    {
        base.Start();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        base.Update();

        if (agent != null && currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            float targetSpeed = (distance > walkDistanceStart) ? runThreshold : walkThreshold;

            agent.speed = targetSpeed;

            float realSpeed = agent.velocity.magnitude;

         
            if (realSpeed < walkThreshold && agent.remainingDistance > 4f)
            {
                realSpeed = runThreshold;
            }

            animator.SetFloat("Speed", realSpeed);



           

            bool hasArrived =
            !agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance + 0.1f &&
            (!agent.hasPath || agent.velocity.sqrMagnitude < 0.05f);

            if (hasArrived && !isAtGoal)
            {
                isAtGoal = true;
                agent.isStopped = true;
                animator.SetTrigger("Salute");
                
            }

        }
      
    }

    public void OnDoneAtGoal()
    {
        isAtGoal = false;
        agent.isStopped = false;
        flameManager.GoalReached(currentTarget);  
        currentTarget = null;
    }
}

  



