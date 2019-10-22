using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        Vector3 desiredMovement = agent.desiredVelocity;
        desiredMovement = transform.InverseTransformDirection(desiredMovement);
        anim.SetFloat("Horizontal", desiredMovement.x);
        anim.SetFloat("Vertical", desiredMovement.z);
    }

    private void OnAnimatorMove()
    {
        agent.velocity = anim.velocity;
        Debug.Log(anim.velocity);
    } 
}
