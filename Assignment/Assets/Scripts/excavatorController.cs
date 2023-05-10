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
        float wheel_on = Input.GetAxis("Fire1");
        float wheel_off = Input.GetAxis("Fire2");
        turnOnSpot(turn, vertical);
        locomote(vertical);
        turnWhileLoco(turn);
        controlWheel(wheel_on, wheel_off);
    }
    void turnOnSpot(float horizontal, float vertical)
    {
        if (vertical == 0)
        {
            if (horizontal > 0) // turn right
            {
                anim.SetBool("righttrack", true);
                anim.SetFloat("rightspeed", -1);
                anim.SetBool("lefttrack", true);
                anim.SetFloat("leftspeed", 1);
            }
            else if (horizontal < 0) // turn left
            {
                anim.SetBool("righttrack", true);
                anim.SetFloat("rightspeed", 1);
                anim.SetBool("lefttrack", true);
                anim.SetFloat("leftspeed", -1);
            }
            else
            {
                anim.SetBool("righttrack", false);
                anim.SetFloat("rightspeed", 1);
                anim.SetBool("lefttrack", false);
                anim.SetFloat("leftspeed", 1);
            }
        }
        else
        {
            anim.SetBool("righttrack", false);
            anim.SetFloat("rightspeed", 1);
            anim.SetBool("lefttrack", false);
            anim.SetFloat("leftspeed", 1);
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
        Vector3 move = new Vector3(-vertical*0.09f, 0f, 0f);
        excavBody.transform.Translate(move);
        if (vertical > 0) // forward
        {
            anim.SetBool("righttrack", true);
            anim.SetFloat("rightspeed", 1);
            anim.SetBool("lefttrack", true);
            anim.SetFloat("leftspeed", 1);
        }
        if (vertical < 0) // backward
        {
            anim.SetBool("righttrack", true);
            anim.SetFloat("rightspeed", -1);
            anim.SetBool("lefttrack", true);
            anim.SetFloat("leftspeed", -1);
        }
    }

    void controlWheel(float wheel_on, float wheel_off)
    {
        if (wheel_on > 0)
        {
            anim.SetBool("wheel", true);
        }
        if (wheel_off > 0)
        {
            anim.SetBool("wheel", false);
        }
    }
}
