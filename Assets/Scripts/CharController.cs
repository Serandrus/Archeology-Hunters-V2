using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharController : MonoBehaviour
{
    private JoystickManager manager;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("Joystick").GetComponent<JoystickManager>();
    }

    void Update()
    {

        float inputX = CrossPlatformInputManager.GetAxis("Horizontal");
        float inputZ = CrossPlatformInputManager.GetAxis("Vertical");


        rb.velocity = new Vector3(inputX, 0, inputZ);
    }
}
