using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class TrailManager : MonoBehaviour {

    public static TrailManager instance;

    [HideInInspector]
    public List<Trail> trailList = new List<Trail>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(this);
        }
    }
}
