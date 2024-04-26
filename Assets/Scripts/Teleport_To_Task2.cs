using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Task2 : MonoBehaviour
{
    public OVRCameraRig cameraRig;
    public LineRenderer teleportLineRenderer;
    public LayerMask teleportMask;
    public float teleportRange = 10f;
    public float rotationInput = 0;
    public GameObject door;

    private Vector3 teleportTarget;
    private bool isTeleporting = false;

    Vector3 GetPointingDir()
    {
        return cameraRig.rightControllerAnchor.transform.forward;
    }

    void Start()
    {
        door.SetActive(true);
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

        if (door.activeSelf)
        {
            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                TeleportToTarget();
            }
        }
    }

    void DisplayIndicator(Vector3 pos)
    {
        door.transform.position = new Vector3(pos.x, 0.8f, pos.z);
        door.SetActive(true);
    }

    void TeleportToTarget()
    {
        // Teleport the user to the Task 2
        transform.position = new Vector3(-145f, 8f, -300f);

        transform.eulerAngles = new Vector3(0, 180, 0);
        door.transform.eulerAngles = new Vector3(0,0,0);
        
        // Set isTeleporting to false after a short delay to prevent rapid teleportation
        Invoke("ResetTeleport", 0.5f);
    }

    void ResetTeleport()
    {
        isTeleporting = false;
        teleportLineRenderer.enabled = false;
    }
}