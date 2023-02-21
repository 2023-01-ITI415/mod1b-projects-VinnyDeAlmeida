using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 leftOffset;
    public Vector3 rightOffset;
    public float cameraSpeed = 0.1f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 cameraPosition = target.position + rightOffset;
            Vector3 lerpPosition = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed);
            transform.position = lerpPosition;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 cameraPosition = target.position + leftOffset;
            Vector3 lerpPosition = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed);
            transform.position = lerpPosition;
        }
    }
}
