using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTrigger : MonoBehaviour
{
    public setUpControlAndCams gamecontroller;
    public bool collided;
    public GameObject excavator;
    public GameObject particle;
    private Animator animator;
    private ParticleSystem particle_playback;

    // Start is called before the first frame update
    void Start()
    {
        animator = excavator.GetComponent<Animator>();
        particle_playback = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (animator.GetBool("wheel"))
        {
            collided = true;
            particle_playback.Play();
        }
    }
}
