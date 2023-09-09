using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size;
    }

    public Pool pool;
    public Queue<GameObject> poolDictionary;


    //
    // @TODO Should it be a Singleton?
    //

    public static PointPooler Instance;

    private void Awake()
    {
        Debug.LogWarning("You are trying to create more than one instance of PointPooler \n|\n Singleton");

        Instance = this;
    }


    public void CreatePool(GameObject prefab)
    {
        pool.prefab = prefab;
        poolDictionary = new Queue<GameObject>();

        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            poolDictionary.Enqueue(obj);
        }
    }

    public void SpawnFromPool(Vector3 pos)      // @TODO Do I want to return the objectToSpawn?
                                                //  Vec2 or Vec3?
    {
        GameObject objectToSpawn = poolDictionary.Dequeue();
        objectToSpawn.transform.position = pos;
        objectToSpawn.SetActive(true);

        poolDictionary.Enqueue(objectToSpawn);
    }


}

