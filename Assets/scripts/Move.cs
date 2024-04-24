using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the speed
    public OVRCameraRig cameraRig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        Debug.Log("A button pressed");

        // Get input from the thumbstick
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        
        // Calculate the movement direction based on the thumbstick input
        Vector3 moveDirection = new Vector3(thumbstickInput.x, 0f, thumbstickInput.y);
        moveDirection = transform.TransformDirection(moveDirection); // Transform relative to the camera's orientation
        
        // Move the camera position
        Quaternion rotate = cameraRig.centerEyeAnchor.rotation;
        transform.position += rotate * moveDirection * moveSpeed * Time.deltaTime;
    }
}