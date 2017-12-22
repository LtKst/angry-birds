using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by: Gijs Schouten
/// </summary>

public class ScoreController : MonoBehaviour {
    private static ScorePopup popupText;
    private static GameObject canvas;
    public static Vector3 screenPos;

    public static void Initialize() {
        print("init");
        canvas = GameObject.Find("WorldCanvas");     
        popupText = Resources.Load<ScorePopup>("Prefabs/PopupParent");      
    }
    
    public static void CreateText(string text, Transform location, Color fontColor, Color outlineColor) {
        ScorePopup instance = Instantiate(popupText);

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPos;
        instance.SetColor(fontColor, outlineColor);
        instance.SetScore(text);
    }
}
