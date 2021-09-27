using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < AmountToPool; i++)
        {
            temp = Instantiate(ObjectToPool);
            temp.SetActive(false);
            PooledObjects.Add(temp);
        }
    }
    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        return null;
    }
}