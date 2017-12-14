using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[Serializable]
public class ObjectPool {

    public string poolName;
    [SerializeField]
    private GameObject poolObject;
    [SerializeField]
    private int initialPoolSize = 10;

    private Transform parent;

    private List<GameObject> objectList = new List<GameObject>();

    /// <summary>
    /// Instantiate an empty object as parent for the pool objects
    /// </summary>
    public void GenerateParent() {
        parent = new GameObject(poolName + "ObjectPoolParent").transform;
    }

    /// <summary>
    /// Fill the pool with objects
    /// </summary>
    public void InitiatePool() {
        for (int i = 0; i < initialPoolSize; i++) {
            GameObject instance = MonoBehaviour.Instantiate(poolObject);
            objectList.Add(instance);

            instance.SetActive(false);
            instance.transform.parent = parent;
        }
    }
    
    /// <summary>
    /// Get an object from the pool or instantiate one if all are used
    /// </summary>
    /// <returns>GameObject</returns>
    public GameObject GetPoolObject() {
        for (int i = 0; i < objectList.Count; i++) {
            if (!objectList[i].activeInHierarchy) {
                objectList[i].SetActive(true);

                return objectList[i];
            }
        }

        // No disabled object in pool, instantiate a new one
        Debug.Log("ObjectPool " + poolName + ": No disabled object in pool, instantiating a new one");

        GameObject instance = MonoBehaviour.Instantiate(poolObject);
        objectList.Add(instance);

        instance.SetActive(false);
        instance.transform.parent = parent;

        return instance;
    }
}
