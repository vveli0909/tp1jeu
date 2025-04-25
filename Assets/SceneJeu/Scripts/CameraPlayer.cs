using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraPlayer : MonoBehaviour
{
    public Transform[] target;        
    public Vector3 offset = new Vector3(0, 5, -6); 
    public float smoothSpeed = 5f;   

    private int currentTargetIndex = 0;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target[currentTargetIndex].position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target[currentTargetIndex]); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentTargetIndex = (currentTargetIndex + 1) % target.Length;
        }
    }

}
