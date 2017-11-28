using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// Not totally happy with how this turned out, might fix it later
/// </summary>
public class ObjectPoolManager : MonoBehaviour {

    public static ObjectPoolManager instance;

    [SerializeField]
    private ObjectPool[] objectPools;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        for (int i = 0; i < objectPools.Length; i++) {
            objectPools[i].GenerateParent();
            objectPools[i].InitiatePool();
        }
    }

    public GameObject SpawnPoolObject(string name) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                return objectPools[i].GetPoolObject();
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    public GameObject SpawnPoolObject(string name, float autoDestroyTime) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                GameObject poolObject = objectPools[i].GetPoolObject();

                StartCoroutine(AutoRemove(poolObject, autoDestroyTime));

                return poolObject;
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    private IEnumerator AutoRemove(GameObject gameObject, float time) {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
