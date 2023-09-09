using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnchorAngle : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private float angle = 0.0f;
    [SerializeField] private float hingeLength = 0.0f;

    public Vector3 GetCubePosition()
    {
        return cube.transform.position;
    }

    public void SetAngle(float newAngle)
    {
        angle = newAngle * (float)Math.PI/180;

        Vector3 oldPos = cube.position;
        Vector3 newPos = new Vector3(transform.position.x + hingeLength * (float)Math.Sin(angle),
                               transform.position.y - hingeLength * (float)Math.Cos(angle),
                               transform.position.z);

        cube.GetComponent<Rigidbody>().velocity = newPos;
    }


    void Start()
    {
        hingeLength = Math.Abs(transform.position.y - cube.position.y);
    }


    void Update()
    {
                
    }
}
