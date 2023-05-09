using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float mouseZ;

    public GameObject target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseZ = Input.GetAxis("Mouse ScrollWheel");

        float angleBetween = Vector3.Angle(Vector3.up, transform.forward);

        // camera controls for both X and Y
        if (Input.GetMouseButton(1)) 
        {
            offset = Quaternion.Euler(0, mouseX, 0) * offset;
            if (((angleBetween > 90) && (mouseY < 0)) || ((angleBetween < 145) && (mouseY > 0)))
            {
                Vector3 LocalRight = target.transform.worldToLocalMatrix.MultiplyVector(transform.right);
                offset = Quaternion.AngleAxis(mouseY, LocalRight) * offset;
            }
        }

        // Calculate distance from target's position and camera position, then add limits to zooming in and out
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (mouseZ > 0 && dist < 8)
        {
            offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
        }
        if (mouseZ < 0 && dist > 2)
        {
            offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.95f));
        }

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);
    }
}
