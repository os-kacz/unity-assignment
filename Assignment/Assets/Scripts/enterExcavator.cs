using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterExcavator : MonoBehaviour
{
    public setUpControlAndCams gamecontroller;
    [SerializeField] private bool enterable;

    private GameObject player;
    [SerializeField] private float elapsed_time;
    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = gamecontroller.GetComponent<setUpControlAndCams>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        elapsed_time = elapsed_time + Time.deltaTime;

        if (gamecontroller.switchControl)
        {
            player.transform.parent = this.transform;
        }
        else
        {
            player.transform.parent = null;
        }

        if (enterable || gamecontroller.switchControl)
        {
            if (Input.GetAxis("Submit") == 1 && elapsed_time > 2)
            {
                gamecontroller.switchControl = !gamecontroller.switchControl;
                elapsed_time = 0;
            }
        }
    }
}
