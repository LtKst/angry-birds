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

        foreach (Collider2D col in colliders) {
            Rigidbody2D rb2D = col.GetComponent<Rigidbody2D>();

            if (rb2D) {
                rb2D.AddExplosionForce(power, explosionPos, radius);
            }
        }
    }
}
