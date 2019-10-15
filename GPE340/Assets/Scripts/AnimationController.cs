using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    public float speed = 3.5f;
    public float turnSpeed = 100f;
    private Transform tf;
    public Camera mouseCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();
        {
            anim = GetComponent<Animator>();
            tf = GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // get the world vector
        Vector3 worldMoveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        worldMoveVector.Normalize();

        // find local version of the worldMoveVector relative to my transform
        Vector3 localMoveVector = transform.InverseTransformDirection(worldMoveVector);

        anim.SetFloat("Horizontal", localMoveVector.x * speed);
        anim.SetFloat("Vertical", localMoveVector.x * speed);

        HandleRotation();
    }

    void HandleRotation()
    {
        Plane groundPlane = new Plane(Vector3.up, tf.position);

        //create a ray from camera through the mouse position, in the direction the camera is facing
        Ray mouseRay = mouseCamera.ScreenPointToRay(Input.mousePosition);

        //Raycast
        float distanceToIntercect;
        if (groundPlane.Raycast(mouseRay, out distanceToIntercect))
        {
            Vector3 collisionPoint = mouseRay.GetPoint(distanceToIntercect);

            //get rotation needed to look at that point
            Quaternion targetRotation = Quaternion.LookRotation(collisionPoint - tf.position, Vector3.up);

            //Rotate 'partway' to that rotation, based on our turn speed
            tf.rotation = Quaternion.RotateTowards(tf.rotation, targetRotation, turnSpeed * Time.deltaTime); 

            tf.LookAt(collisionPoint);
        }
        else
        {
            Debug.LogError("Camera is not looking at plane. No interaction of Ray and Plane.");
        }

    }
}
