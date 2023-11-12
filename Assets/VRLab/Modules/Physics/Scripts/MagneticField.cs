using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicsLab
{
    public class MagneticField : MonoBehaviour
    {
        private bool repulsion = false;
        private bool attraction = false;
        private bool inContact = false;
        private Vector3 otherObjectPosition;
        private float distance;
        [SerializeField] private GameObject magnetParent;

        void Update()
        {
            if (!inContact)
            {
                if (repulsion)
                {
                    distance = Vector3.Distance(otherObjectPosition, transform.position);
                    magnetParent.transform.position = Vector3.MoveTowards(magnetParent.transform.position, otherObjectPosition, distance * Time.deltaTime * -1);
                }
                else if (attraction)
                {
                    distance = Vector3.Distance(otherObjectPosition, transform.position);
                    magnetParent.transform.position = Vector3.MoveTowards(magnetParent.transform.position, otherObjectPosition, distance * Time.deltaTime);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == gameObject.tag)
            {
                otherObjectPosition = other.transform.position;
                repulsion = true;
            }
            else if (other.CompareTag("MagneticNorthPole") || other.CompareTag("MagneticSouthPole"))
            {
                otherObjectPosition = other.transform.position;
                attraction = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            repulsion = false;
            attraction = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            string otherObjectTag = collision.gameObject.tag;
            if (otherObjectTag == "MagneticNorthPole" || otherObjectTag == "MagneticSouthPole")
            {
                inContact = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            string otherObjectTag = collision.gameObject.tag;
            if (otherObjectTag == "MagneticNorthPole" || otherObjectTag == "MagneticSouthPole")
            {
                inContact = false;
            }
        }
    }
}

