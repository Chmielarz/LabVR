using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorAngle : MonoBehaviour
{
    [SerializeField] Transform cube;
    private float angle = 0.0f;
    private float hingeLength = 0.0f;

    public void SetAngle(float newAngle)
    {
        angle = SetAngle;
        auto oldPos = cube.position;
        vec3 newPos = new vec3(oldPos.x + hingeLength * math.sin(angle),
                               oldPos.y + hingeLength * math.cos(angle),
                               oldPos.z);
        
        cube.setPosition(newPos);
    }


    void Start()
    {
        hingeLength = math.abs(transform.position.y - cube.position.y);
    }


    void Update()
    {
                
    }
}
