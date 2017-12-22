using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_HP : MonoBehaviour {

    public int state;

    int timer = 50;

    public Sprite normal;
    public Sprite littledmg;
    public Sprite middmg;
    public Sprite heavydmg;

    public AudioSource woodDamage;
    public AudioSource woodDestroy;
    
    private GameObject bird;

    SpriteRenderer sp;

    // Use this for initialization
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        bird = GameObject.FindGameObjectWithTag("Bird");

        woodDamage = GameObject.Find("woodDamage").GetComponent<AudioSource>();
        woodDestroy = GameObject.Find("woodDestroy").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird" && timer == 0)
        {  
            state += 3;
            woodDamage.Play();
            int amount = 300 + (int)Mathf.Round((bird.GetComponent<Rigidbody2D>().velocity.magnitude * 100));
            ScoreController.screenPos = new Vector3(gameObject.transform.position.x + Random.Range(-2, 2), gameObject.transform.position.y + Random.Range(5, 6));
            ScoreController.CreateText(amount.ToString(), transform, new Color(1, 1, 1), new Color(219f / 255, 159f / 255, 29f / 255));
            ScoreUI.score += amount;
        }
        if (collision.gameObject.tag == "Ground" && timer == 0)
        {
            state += 1;
            ScoreUI.score += 200;
        }
        if (collision.gameObject.tag == "Block" && timer == 0)
        {
            state += 1;
            ScoreUI.score += 100;
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
                sp.sprite = littledmg;
            }
            if (state == 2)
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
                ScoreUI.score += 500;
                woodDestroy.Play();
                ScoreController.screenPos = new Vector3(gameObject.transform.position.x + Random.Range(-2, 2), gameObject.transform.position.y + Random.Range(5, 6));
                ScoreController.CreateText("500", transform, new Color(1, 1, 1), new Color(219f / 255, 159f / 255, 29f / 255));
                ObjectPoolManager.instance.SpawnPoolObject("WoodBreakParticles", transform.position);
                Destroy(gameObject);
                
            }
        }
    }
}
