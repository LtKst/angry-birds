using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class ObjectPoolManager : MonoBehaviour {

    public static ObjectPoolManager instance;

    [SerializeField]
    private ObjectPool[] objectPools;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }

        for (int i = 0; i < objectPools.Length; i++) {
            objectPools[i].GenerateParent();
            objectPools[i].InitiatePool();
        }
    }

    /// <summary>
    /// Find an object pool and get an GameObject from it
    /// </summary>
    /// <param name="name"></param>
    /// <returns>GameObject</returns>
    public GameObject SpawnPoolObject(string name) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                return objectPools[i].GetPoolObject();
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    /// <summary>
    /// Find an object pool and get an GameObject from it and automatically disable it after a set period of time
    /// </summary>
    /// <param name="name"></param>
    /// <param name="autoDisableTime"></param>
    /// <returns>GameObject</returns>
    public GameObject SpawnPoolObject(string name, float autoDisableTime) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                GameObject poolObject = objectPools[i].GetPoolObject();

                StartCoroutine(AutoRemove(poolObject, autoDisableTime));

                return poolObject;
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    /// <summary>
    /// Find an object pool and get an GameObject from it and set it's position
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <returns>GameObject</returns>
    public GameObject SpawnPoolObject(string name, Vector3 position) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                GameObject poolObject = objectPools[i].GetPoolObject();
                poolObject.transform.position = position;

                return poolObject;
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    /// <summary>
    /// Find an object pool and get an GameObject from it, set it's position and automatically disable it after a set period of time
    /// </summary>
    /// <param name="name"></param>
    /// <param name="position"></param>
    /// <param name="autoDisableTime"></param>
    /// <returns>GameObject</returns>
    public GameObject SpawnPoolObject(string name, Vector3 position, float autoDisableTime) {
        for (int i = 0; i < objectPools.Length; i++) {
            if (objectPools[i].poolName == name) {
                GameObject poolObject = objectPools[i].GetPoolObject();
                poolObject.transform.position = position;

                StartCoroutine(AutoRemove(poolObject, autoDisableTime));

                return poolObject;
            }
        }

        Debug.LogWarning("ObjectPoolManager: Object pool not found!");

        return null;
    }

    /// <summary>
    /// Automatically disable an GameObject after a set period of time
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator AutoRemove(GameObject gameObject, float time) {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
