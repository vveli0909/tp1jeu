using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtGoalBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        var controller = animator.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.agent.isStopped = true;
            Debug.Log(" Animation de Salute d�marre !");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        var controller = animator.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.OnDoneAtGoal(); 
            Debug.Log(" Animation termin�e, on repart !");
        }
    }
}
