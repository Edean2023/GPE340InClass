using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Pickup : MonoBehaviour
{
    public float rotationSpeed = 360.0f;
    public float lifeSpan = 5.0f;

    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        // Cashe my transform
        tf = GetComponent<Transform>();

        // make the collider a trigger
        GetComponent<Collider>().isTrigger = true;

        // destroy after lifespan ends
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        tf.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    protected virtual void OnPickup(GameObject other)
    {

    }
    void OnTriggerEnter(Collider other)
    {
        OnPickup(other.gameObject);
        Destroy(gameObject);
    }
}
