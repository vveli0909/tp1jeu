using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedSlowZone : MonoBehaviour
{
    public NavMeshAgent agent;

    public float normalSpeed = 3.5f;
    public float slowSpeed = 1.5f;
    public float boostSpeed = 10f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoostZone"))
        {
            agent.speed = 6f;
            agent.acceleration = 20f;
            Debug.Log("Boost activé !");
            
        }
        else if (other.CompareTag("SlowZone"))
        {
            agent.speed = 1.5f;
            agent.acceleration = 10f;
            Debug.Log("Ralenti !");
        }
    }
    
   void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoostZone") || other.CompareTag("SlowZone"))
        {
            agent.speed = 3.5f;
            agent.acceleration = 8f;
            Debug.Log("Retour à la normale.");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
