using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;

    public bool lookAtPlayer = false;
    public bool isRotationActive = true;
    public float velRotation = 5.0f;

    [Range(0.1f, 1.0f)]
    public float smoothFactor = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        camOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotationActive)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotation, Vector3.up);

            camOffset = camTurnAngle * camOffset;
        }

        Vector3 newPos = player.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer || isRotationActive)
        {
            transform.LookAt(player);
        }
    }
}
