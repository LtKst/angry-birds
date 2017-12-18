using System.Collections;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(ExplosiveBirdAnimation))]
public class ExplosiveBird : Bird {

    private ExplosiveBirdAnimation explosiveBirdAnimation;

    [SerializeField]
    private float detonationTime = 3;

    private void Start() {
        explosiveBirdAnimation = GetComponent<ExplosiveBirdAnimation>();
    }

    public override void OnImpact() {
        base.OnImpact();

        StartCoroutine(WaitForExplosion());
    }

    private IEnumerator WaitForExplosion() {
        explosiveBirdAnimation.ChangeState(ExplosiveBirdAnimation.ExplosiveBirdAnimationState.Exploding);

        yield return new WaitForSeconds(detonationTime);

        Explode();
    }

    private void Explode() {
        ObjectPoolManager.instance.SpawnPoolObject("Explosion", transform.position, 5);

        Destroy(gameObject);
    }
}
