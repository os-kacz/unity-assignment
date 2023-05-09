using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpCameras : MonoBehaviour
{
    public Camera PlayerCamera;
    public Camera ExcavCamera;

    public bool switchCam;

    // Start is called before the first frame update
    void Start()
    {
        switchCam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchCam)
        {
            PlayerCamera.enabled = false;
            ExcavCamera.enabled = true;

            PlayerCamera.GetComponent<AudioListener>().enabled = false;
            ExcavCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            PlayerCamera.enabled = true;
            ExcavCamera.enabled = false;

            PlayerCamera.GetComponent<AudioListener>().enabled = true;
            ExcavCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
