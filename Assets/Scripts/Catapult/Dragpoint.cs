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
    public Vector3 defaulPos;

    public float maxDist;
    public float shootPower;
    public bool canShoot ;
    public Transform midPoint;

    Slingshot SS;

    void Start() {
        canShoot = true;
        SS = GameObject.Find("Slingshot").GetComponent<Slingshot>();
        defaulPos = new Vector3(0, 1.3f, 0);
        transform.position = defaulPos;
    }

    void OnMouseDown() {
        if (canShoot) {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                                Input.mousePosition.y, screenPoint.z));
        }
    }
    void OnMouseDrag() {
        if (canShoot) {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

            var allowedPos = currentPosition - defaulPos;
            allowedPos = Vector3.ClampMagnitude(allowedPos, maxDist);
            transform.position = defaulPos + allowedPos;

            /*if (Input.mousePosition.y >= -100 && Input.mousePosition.y <= 100) {
                Debug.Log("x");
                transform.position = defaulPos;
            }*/
            
        }

    }

    void OnMouseUp() {
        if (canShoot) {
            SS.Shoot(shootPower);
            canShoot = false;
        }
    }
}