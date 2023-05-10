using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructable : MonoBehaviour
{
    public destroyTrigger destroyTrigger;
    private void FixedUpdate()
    {
        if (destroyTrigger.collided)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                child.GetComponent<Rigidbody>().useGravity = true;
                destroyTrigger.collided = false;
            }
        }
    }
}
