using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterExcavator : MonoBehaviour
{
    public setUpControlAndCams gamecontroller;
    private bool enterable;
    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = gamecontroller.GetComponent<setUpControlAndCams>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enterable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterable = false;
        }
    }

    private void FixedUpdate()
    {
        if (enterable)
        {
            if (Input.GetAxis("Submit") == 1)
            {
                gamecontroller.switchControl = !gamecontroller.switchControl;
                enterable = false;
            }
        }
    }
}
