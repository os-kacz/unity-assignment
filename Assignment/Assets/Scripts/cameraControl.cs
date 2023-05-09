using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float mouseZ;
    private int max_dist;
    private int min_dist;

    private setUpControlAndCams cameraScript;
    public GameObject gameController;

    public GameObject target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        cameraScript = gameController.GetComponent<setUpControlAndCams>();
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

        // change min and max distance between excavator and player cameras
        if (cameraScript.switchControl)
        {
            max_dist = 12;
            min_dist = 6;
        }
        else
        {
            max_dist = 8;
            min_dist = 2;
        }

        // Calculate distance from target's position and camera position, then add limits to zooming in and out
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (mouseZ > 0 && dist < max_dist)
        {
            offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
        }
        if (mouseZ < 0 && dist > min_dist)
        {
            offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.95f));
        }

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);
    }
}
