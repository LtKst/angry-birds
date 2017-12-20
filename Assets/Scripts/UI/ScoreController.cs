using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    private static ScorePopup popupText;
    private static GameObject canvas;
    public static Vector3 screenPos;

    public static void Initialize() {
        print("init");
        canvas = GameObject.Find("Canvas");     
        popupText = Resources.Load<ScorePopup>("Prefabs/PopupParent");      
    }
    
    public static void CreateText(string text, Transform location) {
        ScorePopup instance = Instantiate(popupText);
        //Vector2 screenPos = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-2, 2), location.position.y + Random.Range(2 , 4)));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPos;
        instance.SetScore(text);
    }
}
