using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[Serializable]
public class ObjectPool {

    public string poolName;
    public GameObject poolObject;
    public int initialPoolSize = 10;

    [HideInInspector]
    public Transform parent;

    [HideInInspector]
    public List<GameObject> objectList = new List<GameObject>();

    public void GenerateParent() {
        parent = new GameObject(poolName + "Parent").transform;
    }

    public void InitiatePool() {
        for (int j = 0; j < initialPoolSize; j++) {
            GameObject instance = MonoBehaviour.Instantiate(poolObject);
            objectList.Add(instance);

            instance.SetActive(false);
            instance.transform.parent = parent;
        }
    }

    public GameObject GetPoolObject() {
        for (int i = 0; i < objectList.Count; i++) {
            if (!objectList[i].activeInHierarchy) {
                objectList[i].SetActive(true);

                return objectList[i];
            }
        }

        // No disabled object in pool, instantiate a new one
        GameObject instance = MonoBehaviour.Instantiate(poolObject);
        objectList.Add(instance);

        instance.SetActive(false);
        instance.transform.parent = parent;

        return instance;
    }
}
