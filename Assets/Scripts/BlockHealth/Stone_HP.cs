using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_HP : MonoBehaviour {

    public int state;

    int timer = 100;

    public Sprite normal;
    public Sprite littledmg;
    public Sprite middmg;
    public Sprite heavydmg;
    public Sprite broken;

    SpriteRenderer sp;

	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bird" && timer == 0)
        {
            state += 2;
            UI.score += 50000;
        }
    }

    // Update is called once per frame
    void Update () {

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
                sp.sprite = littledmg;
            }
            if(state == 2)
            {
                //mid dmg
                sp.sprite = middmg;
            }
            if (state == 3)
            {
                //heavely dmgd
                sp.sprite = heavydmg;
            }
            if (state >= 4)
            {
                //broken
                sp.sprite = broken;
                Destroy(gameObject);
            }
        }
    }
}
