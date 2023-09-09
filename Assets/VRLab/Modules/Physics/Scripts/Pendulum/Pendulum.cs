
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @TODO add to a namespace

public class Pendulum : MonoBehaviour
{
    [SerializeField] AnchorAngle anchor;
    [SerializeField] private GameObject plotCanvas;

    [SerializeField] private GameObject pt;//temp
    [SerializeField] private float angle = 0.0f;//temp

    private PointPooler pointPool;
    [SerializeField] private float interval = 2.0f; // in seconds

    void Start()
    {
        pointPool = PointPooler.Instance;
    }

    public void StartPendulum()
    {
        InvokeRepeating("SpawnPoint", interval, interval);
        anchor.SetAngle(angle);
        anchor.UnfreezeCube();

    }

    private void SpawnPoint()
    {

        Vector3 cubepos = anchor.GetCubePosition();
        Vector3 newPos = new Vector3(cubepos.x,
            plotCanvas.transform.position.y,
            cubepos.z);

        // get the screen position

        //Vector2 screenPoint = plotCanvas.GetComponent<Canvas>().
        //    .WorldToScreenPoint(Camera.main, worldPosition);

        // convert the screen position to the local anchored position

        //Vector2 anchoredPosition = transform.InverseTransformPoint(screenPoint);

        pointPool.SpawnFromPool(newPos);
    }
}
