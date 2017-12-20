using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public int state;

    int timer = 100;

    public Sprite normal;
    public Sprite dmg;

    SpriteRenderer sp;

    // Use this for initialization
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird" && timer == 0)
        {
            state += 2;
            UI.score += 5000;
        }
        if (collision.gameObject.tag == "Block" && timer == 0)
        {
            state += 1;
            UI.score += 1000;
        }
        if(collision.gameObject.tag == "Ground" && timer == 0)
        {
            state += 1;
            UI.score += 500;
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
                ObjectPoolManager.instance.SpawnPoolObject("Poof", transform.position);
                Destroy(gameObject);
            }
        }
    }
}
