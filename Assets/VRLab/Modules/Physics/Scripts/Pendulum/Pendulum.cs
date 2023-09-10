
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicsLab
{
    public class Pendulum : MonoBehaviour
    {
        [SerializeField] private GameObject pt;//temp


        [SerializeField] AnchorAngle anchor;
        [SerializeField] private GameObject plotCanvas;
        private PointPooler pointPool;

        [SerializeField] private float interval = 2.0f; // in seconds
        [SerializeField] private float angle = 0.0f;

        void Start()
        {
            pointPool = PointPooler.Instance;
            anchor.SetAngle(30.0f);
            //anchor.FreezeCube();
        }

        public void StartPendulum()
        {
            InvokeRepeating("SpawnPoint", interval, interval);
            anchor.UnfreezeCube();
            anchor.SetAngle(angle);
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
}