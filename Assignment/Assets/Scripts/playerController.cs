using UnityEngine;

public class playerController : MonoBehaviour
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
        turnOnSpot(turn);
        locomote(vertical);
        turnWhileLoco(turn);
    }

    void turnOnSpot(float horizontal)
    {
        if (anim.GetFloat("Speed") == 0)
        {
            if (horizontal > 0) // turn right
            {
                anim.SetBool("TurnRight", true);
                anim.SetBool("TurnLeft", false);
            }
            else if (horizontal < 0) // turn left
            {
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", true);
            }
            else
            {
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
        }
        else
        {
            anim.SetBool("TurnRight", false);
            anim.SetBool("TurnLeft", false);
        }
    }

    void turnWhileLoco(float horizontal)
    {
        Rigidbody playerBody = this.GetComponent<Rigidbody>();
        if (horizontal != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, horizontal*2, 0f);
            playerBody.MoveRotation(playerBody.rotation * deltaRotation);
        }
    }

    void locomote(float vertical)
    {
        Rigidbody playerBody = this.GetComponent<Rigidbody>();
        Vector3 move = new Vector3(0f, 0f, vertical*0.07f);
        playerBody.transform.Translate(move);
        if (vertical > 0) // forward
        {
            anim.SetFloat("Speed", vertical * Time.deltaTime * 5);
            anim.SetBool("Walking", true);
            anim.SetBool("Backward", false);
        }
        if (vertical < 0) // backward
        {
            anim.SetFloat("Speed", vertical * Time.deltaTime * 5);
            anim.SetBool("Backward", true);
            anim.SetBool("Walking", false);
        }
        if (vertical == 0) // standstill
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("Walking", false);
            anim.SetBool("Backward", false);
        }
    }
}
