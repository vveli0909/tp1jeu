

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FlameFollower
{
    public Animator animator;

    public float startSlowdownDistance = 6f; //  ralentissement commence plus tôt
    public float walkDistance = 2f;          // Marche lente à cette distance
    public float runSpeed = 3.5f;
    public float walkSpeed = 1.5f;

    protected  void Start()
    {
        base.Start();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    protected  void Update()
    {
        base.Update();

        if (agent != null && currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

            // Calcul de la vitesse lissée
            float targetSpeed = runSpeed;

            if (distance < startSlowdownDistance)
            {
                // Interpolation progressive entre run et walk
                float t = Mathf.InverseLerp(startSlowdownDistance, walkDistance, distance);
                targetSpeed = Mathf.Lerp(walkSpeed, runSpeed, t);
            }

            agent.speed = targetSpeed;

            // Mettre à jour l'animation
            float trueSpeed = agent.velocity.magnitude;
            animator.SetFloat("Speed", trueSpeed);
        }
    }
}

  



