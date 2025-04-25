using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public Vector3 localOffset = new Vector3(6f, 0f, 0f); 
    public float speed = 2f;

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 currentTarget;

    void Start()
    {
        pointA = transform.position;
        pointB = pointA + localOffset;
        currentTarget = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.05f)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }
    }
}
