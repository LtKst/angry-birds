using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
[RequireComponent(typeof(Animator))]
public class ExplosiveBirdAnimation : MonoBehaviour {

    private Animator animator;

    public enum ExplosiveBirdAnimationState { Idle, Shot, Exploding }
    private ExplosiveBirdAnimationState explosiveBirdAnimationState = ExplosiveBirdAnimationState.Idle;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void ChangeState(ExplosiveBirdAnimationState animationState) {
        explosiveBirdAnimationState = animationState;

        switch (explosiveBirdAnimationState) {
            case ExplosiveBirdAnimationState.Shot:

                animator.SetBool("shot", true);

                break;

            case ExplosiveBirdAnimationState.Exploding:

                animator.SetBool("exploding", true);

                break;
        }
    }
}
