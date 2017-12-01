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
    private Vector3 v3 = new Vector3(0.1f, 0.3f, 0);

    private void Start() {
        aimer.transform.position = new Vector3(1, 1, 0);
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        Aim();
        UpdateLines();
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
    }
}
