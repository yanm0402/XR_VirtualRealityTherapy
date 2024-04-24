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
    
    // public void Update()
    // {
    //     OVRInput.Update();

    //     ReadInputs();
    // }


    // private void ReadInputs()
    // {
    //     ///                    RIGHT CONTROLLER
    //     if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.35f)
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //Right Hand Trigger...
    //     if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.35f)
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //A Button...
    //     if (OVRInput.Get(OVRInput.Button.One))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //B Button..
    //     if (OVRInput.Get(OVRInput.Button.Two))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //Thumbstick Button..
    //     if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //thumbstick direction detection
    //     if ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y > 0.1) || (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y < 0.1))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //thumbstick direction detection
    //     if ((OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x > 0.1) || (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x < 0.1))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }



    //     ///                     LEFT CONTROLLER
    //     if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.35f)
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //Right Hand Trigger...
    //     if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.35f)
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //A Button...
    //     if (OVRInput.Get(OVRInput.Button.Three))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //B Button..
    //     if (OVRInput.Get(OVRInput.Button.Four))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //Thumbstick Button..
    //     if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //thumbstick direction detection
    //     if ((OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y > 0.1) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y < 0.1))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }

    //     //thumbstick direction detection
    //     if ((OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0.1) || (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < 0.1))
    //     {
    //         //
    //     }
    //     else
    //     {
    //         //
    //     }
    // }
}