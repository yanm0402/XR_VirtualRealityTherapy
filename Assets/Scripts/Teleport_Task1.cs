using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class Teleport_Task1 : MonoBehaviour
// {
//     public OVRCameraRig cameraRig;
//     public LineRenderer teleportLineRenderer;
//     public GameObject DoorTraining;

//     private Vector3 Target_Task1Position;
//     private bool isTeleporting = false;

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     void Update()
//     {
//         // Check if the right controller button is pressed
//         if (Input.GetButtonDown("OVRInput.Button.One"))
//         {
//             // Cast a ray from the controller
//             RaycastHit hit;
//             if (Physics.Raycast(transform.position, transform.forward, out hit, maxTeleportDistance, teleportLayer))
//             {
//                 // Check if the hit object is a valid teleportation target
//                 if (hit.collider.CompareTag("TeleportTarget"))
//                 {
//                     // Teleport the player to the hit position
//                     TeleportPlayer(hit.point);
//                 }
//             }
//         }
//     }

//     void TeleportPlayer(Vector3 newPosition)
//     {
//         // Ensure the player is not already teleporting
//         if (!isTeleporting)
//         {
//             // Set isTeleporting to true to prevent multiple teleportations at once
//             isTeleporting = true;

//             // Move the player to the new position
//             player.position = newPosition;

//             // Reset isTeleporting after a short delay (to prevent rapid teleportation)
//             Invoke("ResetTeleportFlag", 0.5f);
//         }

//         void ResetTeleportFlag()
//         {
//             isTeleporting = false;
//         }
//     }
// }


public class Teleport_Task1 : MonoBehaviour
{
    public OVRCameraRig cameraRig;
    public LineRenderer teleportLineRenderer;
    public LayerMask teleportMask;
    public float teleportRange = 10f;
    public float rotationInput = 0;
    public GameObject DoorTraining;
    // public GameObject arrow;

    private Vector3 teleportTarget;
    private bool isTeleporting = false;

    Vector3 GetPointingDir()
    {
        return cameraRig.rightControllerAnchor.transform.forward;
    }

    void Start()
    {
        DoorTraining.SetActive(false);
    }

    void Update()
    {
        if (!isTeleporting)
        {
            // Cast a ray into the scene
            RaycastHit hit;
            var rightTransform = cameraRig.rightControllerAnchor.transform;
            
            if (Physics.Raycast(rightTransform.position, rightTransform.forward, out hit))
            {
                // Visualize the ray using LineRenderer
                teleportLineRenderer.enabled = true;
                teleportLineRenderer.SetPosition(0, rightTransform.position);
                teleportLineRenderer.SetPosition(1, hit.point);

                // Store the teleport target position
                teleportTarget = hit.point;               
            }
            else
            {
                teleportLineRenderer.enabled = false;
            }            
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.5f)
        {
            DisplayIndicator(teleportTarget);        
        }

        if (DoorTraining.activeSelf)
        {
            // AdjustArrow();
            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                TeleportToTarget();
            }
        }
    }

    void DisplayIndicator(Vector3 pos)
    {
        DoorTraining.transform.position = new Vector3(pos.x, 0.8f, pos.z);
        DoorTraining.SetActive(true);
    }

    // void AdjustArrow()
    // {
    //     Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        
    //     if (thumbstickInput.x < 0)
    //     {
    //         arrow.transform.Rotate(0, -3, 0);
    //     }
    //     else if (thumbstickInput.x > 0)
    //     {
    //         arrow.transform.Rotate(0, 3, 0);
    //     }
    // }

    void TeleportToTarget()
    {
        // Teleport the user to the selected location and orientation
        transform.position = new Vector3(teleportTarget.x, 1, teleportTarget.z);

        // transform.rotation = arrow.transform.rotation;
        transform.eulerAngles = new Vector3(0, 0, 0);
        DoorTraining.SetActive(false);
        DoorTraining.transform.eulerAngles = new Vector3(0,0,0);
        
        // Set isTeleporting to false after a short delay to prevent rapid teleportation
        Invoke("ResetTeleport", 0.5f);
    }

    void ResetTeleport()
    {
        isTeleporting = false;
    } 
}