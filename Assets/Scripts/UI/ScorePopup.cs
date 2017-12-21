using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Made by: Gijs Schouten
/// </summary>

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
    
}
