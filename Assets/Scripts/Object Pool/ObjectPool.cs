using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// Not totally happy with how this turned out, might fix it later
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
