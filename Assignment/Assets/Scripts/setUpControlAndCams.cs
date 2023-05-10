using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUpControlAndCams : MonoBehaviour
{
    public Camera PlayerCamera;
    public Camera ExcavCamera;

    public GameObject excavator;
    private excavatorController excavControl;
    public GameObject player;
    private playerController playerControl;

    public bool switchControl;

    // Start is called before the first frame update
    void Start()
    {
        switchControl = false;
        excavControl = excavator.GetComponent<excavatorController>();
        playerControl = player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switchControl)
        {
            PlayerCamera.enabled = false;
            player.SetActive(false);
            ExcavCamera.enabled = true;

            playerControl.enabled = false;
            excavControl.enabled = true;

            PlayerCamera.GetComponent<AudioListener>().enabled = false;
            ExcavCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            PlayerCamera.enabled = true;
            player.SetActive(true);
            ExcavCamera.enabled = false;

            playerControl.enabled = true;
            excavControl.enabled = false;

            PlayerCamera.GetComponent<AudioListener>().enabled = true;
            ExcavCamera.GetComponent<AudioListener>().enabled = false;
        }
    }
}
