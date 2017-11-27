using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class Bird : MonoBehaviour {
    
    [SerializeField]
    private float damage = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        OnImpact();
    }

    public virtual void OnImpact() {
        print("I hit something");
    }
}
