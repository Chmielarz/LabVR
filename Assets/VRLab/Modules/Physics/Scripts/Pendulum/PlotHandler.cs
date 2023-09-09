using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotHandler : MonoBehaviour
{
    [SerializeField] private GameObject plotCanvas;
    [SerializeField] private GameObject point;

    private PointPooler pointPool;

    void Start()
    {
        pointPool = PointPooler.Instance;
    }

    void Update()
    {
        
    }
}
