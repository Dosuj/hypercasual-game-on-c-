using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anet : MonoBehaviour
{
    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null)
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Remove(other.attachedRigidbody);
        }
    }
    void FixedUpdate()
    {
        foreach (Rigidbody body in affectedBodies)
        {
            Vector3 directionToPlanet = (transform.position - body.position).normalized;

            body.AddForce(directionToPlanet * 10000);
        }
    }
}
