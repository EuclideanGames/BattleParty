using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public static PanCamera Active;
    public Camera Camera;
    public float CameraSpeed;

    private static GameObject target;
    private static bool targetLocked;

    private Vector3 followVelocity;

    private void Awake()
    {
        Active = this;
        Camera = GetComponent<Camera>();
        
        target = null;
        targetLocked = false;
    }

    private void Start()
    {

    }

    private void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        Vector3 cameraMovement;

        if(horiz != 0.0f || vert != 0.0f)
        {
            targetLocked = false;

            cameraMovement = new Vector3(horiz, vert, 0.0f);
            cameraMovement *= CameraSpeed * Time.deltaTime;

            transform.position += cameraMovement;
        }
        else if (targetLocked)
        {
            var tarPos = target.transform.position;
            tarPos.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                tarPos,
                ref followVelocity,
                0.05f,
                CameraSpeed);

            if (Vector3.Distance(transform.position, tarPos) > 0.01f)
                cameraMovement = (tarPos - transform.position).normalized;
        }
    }

    public static void SetTarget(GameObject newTarget)
    {
        target = newTarget;
        targetLocked = true;
    }
}
