using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excavatorController : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        turnOnSpot(turn, vertical);
        locomote(vertical);
        turnWhileLoco(turn);
    }
    void turnOnSpot(float horizontal, float vertical)
    {
        if (vertical == 0)
        {
            if (horizontal > 0) // turn right
            {
                anim.SetBool("righttrack", true);
                anim.SetBool("lefttrack", false);
            }
            else if (horizontal < 0) // turn left
            {
                anim.SetBool("righttrack", false);
                anim.SetBool("lefttrack", true);
            }
        }
        else
        {
            anim.SetBool("righttrack", false);
            anim.SetBool("lefttrack", false);
        }
    }

    void turnWhileLoco(float horizontal)
    {
        Rigidbody excavBody = this.GetComponent<Rigidbody>();
        if (horizontal != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, horizontal*2, 0f);
            excavBody.MoveRotation(excavBody.rotation * deltaRotation);
        }
    }

    void locomote(float vertical)
    {
        Rigidbody excavBody = this.GetComponent<Rigidbody>();
        Vector3 move = new Vector3(-vertical*0.07f, 0f, 0f);
        excavBody.transform.Translate(move);
        if (vertical > 0) // forward
        {
            ;
        }
        if (vertical < 0) // backward
        {
            ;
        }
        if (vertical == 0) // standstill
        {
            ;
        }
    }
}
