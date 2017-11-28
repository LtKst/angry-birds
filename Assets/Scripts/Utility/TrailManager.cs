using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour {

    public static TrailManager instance;

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
