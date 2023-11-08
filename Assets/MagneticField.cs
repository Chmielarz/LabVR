using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    private Transform otherObjectTransform;
    private Transform selfTransform;
    private float distanceBetween;
    private bool isConnected = false;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (otherObjectTransform && !isConnected)
        {
            distanceBetween = Vector3.Distance(otherObjectTransform.position, selfTransform.position);
            selfTransform.position = Vector3.MoveTowards(selfTransform.position, otherObjectTransform.position, distanceBetween * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MagneticNorthPole")
        {
            otherObjectTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        otherObjectTransform = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isConnected = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isConnected = false;
    }


}
