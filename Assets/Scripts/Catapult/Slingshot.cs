using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Made by: Gijs Schouten
/// </summary>

public class Slingshot : MonoBehaviour {
    public float lineSpeed;
    public float xPower = 0.1f;
    public float yPower = 0.3f;
    public float widthVar = 3;
    public GameObject bird;
    public GameObject aimer;
    public Transform midPoint;
    public GameObject[] anchors;
    private bool shoot = false;
    private Vector3 v3;

    [SerializeField]
    private CameraPan cameraPan;

    private void Start() {
        ScoreController.Initialize();
        v3 = new Vector3(xPower, yPower, 0);
        aimer.transform.position = new Vector3(1, 1, 0);
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        Aim();

        if (shoot) {
            anchors[0].GetComponent<LineRenderer>().SetPosition(1, Vector3.MoveTowards(anchors[0].GetComponent<LineRenderer>().GetPosition(1), midPoint.position, lineSpeed * Time.deltaTime));
            anchors[1].GetComponent<LineRenderer>().SetPosition(1, Vector3.MoveTowards(anchors[1].GetComponent<LineRenderer>().GetPosition(1), midPoint.position, lineSpeed * Time.deltaTime));
        } else {
            UpdateLines();
        }
    }

    private void UpdateLines() {
        for(int i = 0; i < anchors.Length; i++) {
            anchors[i].GetComponent<LineRenderer>().SetPosition(0, anchors[i].transform.position);
            anchors[i].GetComponent<LineRenderer>().SetPosition(1, bird.transform.position);
            anchors[i].GetComponent<LineRenderer>().SetWidth(widthVar - Vector3.Distance(midPoint.position, bird.transform.position) / 3, widthVar - Vector3.Distance(midPoint.position, bird.transform.position) / 3);
        }
    }

    private void Aim() {
        if (bird != null) {
            Vector3 pullDirection = midPoint.position - (bird.transform.position - midPoint.position).normalized;
            aimer.transform.position = pullDirection;
        }
    }

    Vector3 GetShotDirection() {
        Vector3 shotDir = (aimer.transform.position - midPoint.transform.position).normalized + v3;
        return shotDir;
    }   

    public void Shoot(float power) {
        cameraPan.inAction = true;
        bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        bird.GetComponent<Rigidbody2D>().AddForce(GetShotDirection() * power * 2.5f, ForceMode2D.Impulse);
        bird.GetComponent<ExplosiveBirdAnimation>().ChangeState(ExplosiveBirdAnimation.ExplosiveBirdAnimationState.Shot);
        bird.GetComponent<Bird>().shot = true;
        shoot = true;
    }
}
