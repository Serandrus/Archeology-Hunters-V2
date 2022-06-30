using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;

    //public bool lookAtPlayer = false;
    //public bool isRotationActive = true;
    //public float velRotation = 5.0f;

    [Range(0.1f, 1.0f)]
    public float smoothFactor = 0.1f;

    private Touch initTouch = new Touch();
    public Camera cam;

    private float rotX = 0f;
    private float rotY = 0f;
    private Vector3 origRot;

    public float rotSpeed = 0.5f;
    public float dir = -1;

    private void Start()
    {
        camOffset = transform.position - player.position;
        origRot = cam.transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                //Swiping
                float deltaX = initTouch.position.x - touch.position.x;
                //float deltaY = initTouch.position.y - touch.position.y;
                //rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                rotX = Mathf.Clamp(rotX, -80f, 80f);
                cam.transform.eulerAngles = new Vector3(rotX, rotY, 0f);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }

        //if (isRotationActive)
        //{
        //    Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotation, Vector3.up);

        //    camOffset = camTurnAngle * camOffset;
        //}

        Vector3 newPos = player.position + camOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        //if (lookAtPlayer || isRotationActive)
        //{
        //    transform.LookAt(player);
        //}
    }
}
