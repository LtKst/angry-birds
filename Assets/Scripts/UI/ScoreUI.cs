using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    [SerializeField]
    public Text scoreText;
    public static int score = 0;
    int highscore = 88730;
    string space = "";
	
    void Start() {
        score = 0;
    }

	// Update is called once per frame
	void Update () {

        scoreText.text = "highscore: " + highscore + "\n" + "score: " + space + score;

        if(score < 10)
        {
            space = "           ";
        }
        if(score >= 10 && score < 100)
        {
            space = "        ";
        }
        if(score >= 100 && score < 1000)
        {
            space = "     ";
        }
        if(score >= 1000 && score < 10000)
        {
            space = "  ";
        }
        if(score >= 10000)
        {
            space = "";
        }

        if(highscore < score)
        {
            highscore = score;
        }
		
	}
}
