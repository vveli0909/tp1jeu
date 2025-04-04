using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour {
    public NavMeshAgent capsule; 
    public bool shouldMove = true;
    public BoxCollider box; 
    // Update is called once per frame
    void Update() { 
        if (shouldMove) 
        { 
            capsule.SetDestination(box.transform.position); 
        } 
    } 
}