using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int state;

    int timer = 100;

    public Sprite normal;
    public Sprite dmg;

    public AudioSource pigDestroy;

    SpriteRenderer sp;

    // Use this for initialization
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        pigDestroy = GameObject.Find("pigDestroy").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird" && timer == 0)
        {
            state += 2;
            ScoreUI.score += 5000;
        }
        if (collision.gameObject.tag == "Block" && timer == 0)
        {
            state += 1;
            ScoreUI.score += 1000;
        }
        if(collision.gameObject.tag == "Ground" && timer == 0)
        {
            state += 1;
            ScoreUI.score += 500;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0)
        {
            timer -= 1;
        }

        if (timer == 0)
        {
            if (state == 0)
            {
                //No dmg
                sp.sprite = normal;
            }
            if (state == 1)
            {
                //little dmg
                sp.sprite = dmg;
            }
            if (state >= 2)
            {
                //broken
                ScoreUI.score += 5000;
                pigDestroy.Play();
                ScoreController.screenPos = new Vector3(gameObject.transform.position.x + Random.Range(-2, 2), gameObject.transform.position.y + Random.Range(5, 6));
                ScoreController.CreateText("5000", transform);
                ObjectPoolManager.instance.SpawnPoolObject("Poof", transform.position);
                Destroy(gameObject);
            }
        }
    }
}
