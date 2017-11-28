using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class ExplosiveBird : Bird {

    [SerializeField]
    private float detonationTime = 3;

    private void Start() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0.5f) * 500);
    }

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
