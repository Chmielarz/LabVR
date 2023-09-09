
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] AnchorAngle anchor;

    void setAngle(float angle)
    {
        anchor.SetAngle(angle);
    }

    // Start is called before the first frame update
    void Start()
    {
        setAngle(40.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
