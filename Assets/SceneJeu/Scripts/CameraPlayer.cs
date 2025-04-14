using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform target;         // La capsule à suivre
    public Vector3 offset = new Vector3(0, 5, -6); // Position relative
    public float smoothSpeed = 5f;   // Vitesse de lissage du mouvement
    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Oriente la caméra vers la capsule
    }
}
