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

        for (int i = 0; i < colliders.Length; i++) {
            Rigidbody2D rb2D = colliders[i].GetComponent<Rigidbody2D>();

            if (rb2D) {
                rb2D.AddExplosionForce(power, explosionPos, radius);
            }
        }
    }
}
