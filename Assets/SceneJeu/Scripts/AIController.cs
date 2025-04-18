using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour { 
    public NavMeshAgent agent; 
    // Start is called before the first frame update
    void Start() { 
        agent = GetComponent<NavMeshAgent>(); 
    } 
    // Update is called once per frame
    void Update() { 
        if (Input.GetMouseButtonDown(0)) { 
            RaycastHit hit; 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) { 
                agent.SetDestination(hit.point); 
            } 
        } 
    } 
}