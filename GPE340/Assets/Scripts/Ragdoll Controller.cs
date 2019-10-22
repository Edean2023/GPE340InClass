using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    private CapsuleCollider mainCapsuleCollider;
    private Rigidbody mainRigidbody;
    private Animator animator;
    private Rigidbody[] ragdollRigidBodies;
    private CapsuleCollider[] ragdollColliders;

    // Start is called before the first frame update
    void Start()
    {
        mainCapsuleCollider = GetComponent<CapsuleCollider>();
        mainRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           

        }
    }

    void toggleragdoll(bool isOn)
    {
        if (isOn)
        {
            for(int i = 0; i < ragdollColliders.Length; i++)
            {
                ragdollColliders[i].enabled = true;
            }
            // turn on ragdoll
            // turn off main elements
            mainCapsuleCollider.enabled = false;
            animator.enabled = false;
            mainRigidbody.isKinematic = true;
        }
        else
        {
            // turn off main elements
            // turn on ragdoll
            mainCapsuleCollider.enabled = true;
            animator.enabled = true;
            mainRigidbody.isKinematic = false;
        }
    }

}
