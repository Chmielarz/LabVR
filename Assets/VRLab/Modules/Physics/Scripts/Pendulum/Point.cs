using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour, IPooledPoint
{
    private bool isMoving = false;
    public void OnObjectSpawn()   // @TODO coroutine?
                                  // maybe move it in a grid?
    {
        isMoving = true;
        // move it as long it reaches the goal, then go inActive
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;

        transform.position += new Vector3(1, 1, 1);     // ## 
    }

}
