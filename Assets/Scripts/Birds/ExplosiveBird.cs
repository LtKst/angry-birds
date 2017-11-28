using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class ExplosiveBird : Bird {

    [SerializeField]
    private float detonationTime = 3;
    
    public override void OnImpact() {
        base.OnImpact();

        StartCoroutine(WaitForExplosion());
    }

    private IEnumerator WaitForExplosion() {
        yield return new WaitForSeconds(detonationTime);

        ObjectPoolManager.instance.SpawnPoolObject("Explosion", 5).transform.position = transform.position;

        Destroy(gameObject);
    }
}
