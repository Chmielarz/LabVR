using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysicsLab
{
    public class PointPooler : MonoBehaviour
    {

        [System.Serializable]
        public class Pool
        {
            public GameObject prefab;
            public int size;
        }

        public Pool pool;
        public Queue<GameObject> poolQueue;

        // @TODO Should it be a Singleton?
        #region Singleton
        public static PointPooler Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogWarning("You are trying to create more than one instance of PointPooler \n|\n Singleton");
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        #endregion

        public void CreatePool(GameObject prefab)
        {
            pool.prefab = prefab;
            poolQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                poolQueue.Enqueue(obj);
            }
        }

        public void SpawnFromPool(Vector2 pos)
        {
            GameObject objectToSpawn = poolQueue.Dequeue();
            objectToSpawn.transform.position = pos;
            objectToSpawn.SetActive(true);

            poolQueue.Enqueue(objectToSpawn);

            objectToSpawn.GetComponent<IPooledPoint>().OnObjectSpawn();     // @TODO Maybe get rid of the GetComponent Call
        }

        
    }
}
