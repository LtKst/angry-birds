using UnityEngine;
using System.Collections;

/// <summary>
/// Made by: Gijs Schouten
/// </summary>

public class Dragpoint : MonoBehaviour {

    [HideInInspector]
    public Vector3 currentPosition;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 defaulPos;

    Slingshot SS;

    void Start() {
        SS = GameObject.Find("Slingshot").GetComponent<Slingshot>();
        defaulPos = new Vector3(0, 1.3f, 0);
        transform.position = defaulPos;
    }

    void OnMouseDown() {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                            Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }
    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        transform.position = currentPosition;
    }
    void OnMouseUp() {
        Cursor.visible = true;
        SS.Shoot(15);
    }
}