using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnchorAngle : MonoBehaviour
{
    [SerializeField] private float angle = 0.0f;        // @TODO the player should be able to set the angle with his hands
    private float hingeLength = 0.0f;

    [SerializeField] private Transform cube;
    private Rigidbody rb_cube;


    public Vector3 GetCubePosition()
    {
        return cube.transform.position;
    }

    public void FreezeCube()
    {
        rb_cube.isKinematic = true;
    }

    public void UnfreezeCube()
    {
        rb_cube.isKinematic = false;
    }

    public void SetAngle(float newAngle)
    {
        angle = newAngle * (float)Math.PI/180;

        Vector3 newPos = new Vector3(transform.position.x + hingeLength * (float)Math.Sin(angle),
                               transform.position.y - hingeLength * (float)Math.Cos(angle),
                               transform.position.z);

        rb_cube.velocity = newPos;
    }

    void Start()
    {
        hingeLength = Math.Abs(transform.position.y - cube.position.y);
        rb_cube = cube.GetComponent<Rigidbody>();
    }


}
