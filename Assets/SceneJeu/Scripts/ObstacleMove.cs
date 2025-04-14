using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;
    private Vector3 target;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        if (target == null || pointA == null || pointB == null) return;

        // Déplacer vers le point cible
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Vérifier si atteint destination
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            // Inverser la cible
            target = (target == pointA) ? pointB : pointA;
        }
    }
}

