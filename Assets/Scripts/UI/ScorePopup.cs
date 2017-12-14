using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour {
    Rect text;
    private GUIStyle style;
    public Font abFont;

    private void Start() {
        text = new Rect(0,0,1000,1000);
        style = new GUIStyle();


    }

    private void OnGUI() {
        style.font = abFont;
        GUILayout.Label("", style);
        GUI.Label(text, "500");
                 
    }
}
