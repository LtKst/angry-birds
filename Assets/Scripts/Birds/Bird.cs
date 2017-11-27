using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Bird : MonoBehaviour {

    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float damage = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        OnImpact(collision);
    }

    public virtual void OnImpact(Collision2D collision) {
        print("I hit something");
    }
}
