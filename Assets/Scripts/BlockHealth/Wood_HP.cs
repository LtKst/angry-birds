using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_HP : MonoBehaviour {

    int state = 0;
    int timer = 100;
    int hp = 200;

    float speed;

    // Use this for initialization
    void Start () {
        
    }

    private void FixedUpdate()
    {
        speed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(timer == 0 && speed < 5 && collision.gameObject.name != "Bird") //speed and ground hit
        {
            hp -= 20;
        }else if(timer == 0 && speed > 5 && speed < 10 && collision.gameObject.name != "Bird") //speed and ground hit
        { 
            hp -= 50;
        }else if(collision.gameObject.name == "Bird" && timer == 0) //player hit
        {
            state += 3;
        }
    }

    // Update is called once per frame
    void Update () {

        Debug.Log(hp);

        if (timer > 0)
        {
            timer -= 1;
        }

        if(hp <= 0)
        {
            state += 1;
            hp = 100;
        }

        if (timer == 0)
        {
            if (state == 0)
            {
                //No dmg
                Debug.Log("No DMG");
            }
            if (state == 1)
            {
                //little dmg
                Debug.Log("oof little dmg");
            }
            if (state == 2)
            {
                //heavely dmgd
                Debug.Log("oof im heavely dmgd");
            }
            if (state >= 3)
            {
                //broken
                Debug.Log("im ded");
                Destroy(gameObject);
            }
        }
	}
}
