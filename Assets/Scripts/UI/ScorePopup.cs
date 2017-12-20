using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePopup : MonoBehaviour {
    public Animator anim;
    private Text scoreText;

    private void OnEnable() {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        scoreText = anim.GetComponent<Text>();
    }

    public void SetScore(string score) {
        scoreText.text = score;
    }
    /*int amount = 300 + (int)Mathf.Round(bird.GetComponent<Rigidbody2D>().velocity.magnitude) * 10;
            ScoreController.CreateText(amount.ToString(), transform);
            UI.score += amount;*/
}
