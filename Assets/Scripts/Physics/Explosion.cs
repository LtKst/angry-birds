using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Explosion : MonoBehaviour {

    [SerializeField]
    private float radius = 5f;
    [SerializeField]
    private float power = 10f;

    private void Start() {
        Vector3 explosionPos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
        Collider2D[] damageColliders = Physics2D.OverlapCircleAll(explosionPos, radius / 2);

        foreach (Collider2D col in colliders) {
            Rigidbody2D rb2D = col.GetComponent<Rigidbody2D>();

            if (rb2D) {
                rb2D.AddExplosionForce(power, explosionPos, radius);
            }
        }

        foreach (Collider2D col in damageColliders) {
            Wood_HP woodHP = col.GetComponent<Wood_HP>();
            Stone_HP stoneHP = col.GetComponent<Stone_HP>();
            EnemyHealth enemyHP = col.GetComponent<EnemyHealth>();

            if (woodHP) {
                woodHP.state += 3;
            }

            if (stoneHP) {
                stoneHP.state += 3;
            }

            if (enemyHP) {
                enemyHP.state += 2;
            }
        }
    }
}
