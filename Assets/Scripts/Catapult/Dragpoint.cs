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
    [HideInInspector]
    public Vector3 defaultPos;

    public float maxDist;
    public float shootPower;
    public bool canShoot ;
    public Transform midPoint;

    Slingshot SS;

    void Start() {
        defaultPos = transform.position;
        canShoot = true;
        SS = GameObject.Find("Slingshot").GetComponent<Slingshot>();
    }

    void OnMouseDown() {
        if (canShoot && !Pause.Paused) {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                                Input.mousePosition.y, screenPoint.z));
        }
    }
    void OnMouseDrag() {
        if (canShoot && !Pause.Paused) {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

            var allowedPos = currentPosition - defaultPos;
            allowedPos = Vector3.ClampMagnitude(allowedPos, maxDist);
            transform.position = defaultPos + allowedPos;

            /*if (Input.mousePosition.y >= -100 && Input.mousePosition.y <= 100) {
                Debug.Log("x");
                transform.position = defaulPos;
            }*/
            
        }

    }

    void OnMouseUp() {
        if (canShoot && !Pause.Paused) {
            SS.Shoot(shootPower);
            canShoot = false;
        }
    }
}