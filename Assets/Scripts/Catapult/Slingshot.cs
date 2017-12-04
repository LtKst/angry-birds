using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by: Gijs Schouten
/// </summary>

public class Slingshot : MonoBehaviour {
    public GameObject bird;
    public GameObject aimer;
    public Transform midPoint;
    public GameObject[] anchors;
    private bool shoot = false;
    private Vector3 v3 = new Vector3(0.1f, 0.3f, 0);

    private void Start() {
        aimer.transform.position = new Vector3(1, 1, 0);
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        Aim();

        if (shoot) {
            anchors[0].GetComponent<LineRenderer>().SetPosition(1, Vector3.MoveTowards(anchors[0].GetComponent<LineRenderer>().GetPosition(1), midPoint.position, 1 * Time.deltaTime));
            anchors[1].GetComponent<LineRenderer>().SetPosition(1, Vector3.MoveTowards(anchors[1].GetComponent<LineRenderer>().GetPosition(1), midPoint.position, 1 * Time.deltaTime));
        } else {
            UpdateLines();
        }
    }

    private void UpdateLines() {
        for(int i = 0; i < anchors.Length; i++) {
            anchors[i].GetComponent<LineRenderer>().SetPosition(0, anchors[i].transform.position);
            anchors[i].GetComponent<LineRenderer>().SetPosition(1, bird.transform.position);
        }
    }

    private void Aim() {
        Vector3 pullDirection = midPoint.position - (bird.transform.position - midPoint.position).normalized;
        aimer.transform.position = pullDirection;
    }

    Vector3 GetShotDirection() {
        Vector3 shotDir = (aimer.transform.position - midPoint.transform.position).normalized + v3;
        return shotDir;
    }   

    public void Shoot(float power) {
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        bird.GetComponent<Rigidbody2D>().AddForce(GetShotDirection() * power * 2.5f, ForceMode2D.Impulse);
        bird.GetComponent<Dragpoint>().canShoot = false;
        //anchors[0].GetComponent<LineRenderer>().enabled = false;
        //anchors[1].GetComponent<LineRenderer>().enabled = false;
        shoot = true;
        

    }
}
