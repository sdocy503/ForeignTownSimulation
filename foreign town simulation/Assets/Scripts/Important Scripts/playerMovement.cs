using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour {
    public float speed;
    public bool Smooth;
    public static bool playoutofbedanim;

    public Text daytext;

    public Sprite walkright1;
    public Sprite walkright2;
    public Sprite walkright3;
    public Sprite walkright4;

    public Sprite walkleft1;
    public Sprite walkleft2;
    public Sprite walkleft3;
    public Sprite walkleft4;

    public Sprite walkup1;
    public Sprite walkup2;
    public Sprite walkup3;
    public Sprite walkup4;

    public Sprite walkdown1;
    public Sprite walkdown2;
    public Sprite walkdown3;
    public Sprite walkdown4;

    public Sprite outofbed1;
    public Sprite outofbed2;
    public Sprite outofbed3;
    public Sprite outofbed4;

    private SpriteRenderer spriterenderer;

    bool showtext;
    bool animinplay;

    public int check = 1;
    float walktime = 1.0f;
    public float animationtimer;
    public float texttimer;
	// Use this for initialization
	void Start () {
        spriterenderer = GetComponent<SpriteRenderer>();
        animationtimer = 0.23f;
        texttimer = 3.0f;
        playoutofbedanim = false;
        showtext = false;
        animinplay = true;
    }
	
	// Update is called once per frame
	void Update () {
        animationtimer -= Time.deltaTime;

        if (showtext)
        {
            texttimer -= Time.deltaTime;

            daytext.text = "Slept to next day. Current Day: " + dayNight.dayCount;

            if (texttimer <= 0.0f)
            {
                showtext = false;
                daytext.text = "";
                texttimer = 3.0f;
            }
        }

        if (animinplay)
        {
            if (animationtimer <= 0.0f)
            {
                check += 1;
                animationtimer = 0.23f;

                if (check == 5)
                {
                    check = 1;
                }
            }
        }
        else
        {
            check = 1;
        }

        if (playoutofbedanim)
        {

            walktime -= Time.deltaTime;

            if (walktime <= 0.0f)
            {
                animinplay = true;
                getoutofbed();
            }
            else
            {
                animinplay = true;
                transform.Translate(Time.deltaTime * -speed, 0, 0);
                walkleft();
            }    
        }
        else
        {
            if (!dayNight.lockmovement)
            {
                if (Input.GetKey("`") && Input.GetKeyDown("="))
                {
                    speed += 2.5f;
                }
                else if (Input.GetKey("`") && Input.GetKeyDown("-"))
                {
                    speed -= 2.5f;
                }

                if (Input.GetKey("w"))
                {
                    animinplay = true;
                    //Debug.Log("Up");
                    transform.Translate(0, Time.deltaTime * speed, 0);
                    walkup();
                }
                if (Input.GetKey("a"))
                {
                    animinplay = true;
                    //Debug.Log("Left");
                    transform.Translate(Time.deltaTime * -speed, 0, 0);
                    walkleft();
                }
                if (Input.GetKey("s"))
                {
                    animinplay = true;
                    //Debug.Log("Down");
                    transform.Translate(0, Time.deltaTime * -speed, 0);
                    walkdown();
                }
                if (Input.GetKey("d"))
                {
                    animinplay = true;
                    //Debug.Log("down");
                    transform.Translate(Time.deltaTime * speed, 0, 0);
                    walkright();
                }

                //makes diagonal walking look a little better
                if (Input.GetKey("w") && (Input.GetKey("d")))
                {
                    animinplay = true;
                    walkup();
                }
                if (Input.GetKey("s") && (Input.GetKey("d")))
                {
                    animinplay = true;
                    walkright();
                }
                if (Input.GetKey("w") && (Input.GetKey("a")))
                {
                    animinplay = true;
                    walkup();
                }
                if (Input.GetKey("s") && (Input.GetKey("a")))
                {
                    animinplay = true;
                    walkleft();
                }

                if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d"))
                {
                    if (spriterenderer.sprite == walkright1 || spriterenderer.sprite == walkright2 || spriterenderer.sprite == walkright3 || spriterenderer.sprite == walkright4)
                    {
                        spriterenderer.sprite = walkright1;
                    }
                    else if (spriterenderer.sprite == walkleft1 || spriterenderer.sprite == walkleft2 || spriterenderer.sprite == walkleft3 || spriterenderer.sprite == walkleft4)
                    {
                        spriterenderer.sprite = walkleft1;
                    }
                    else if (spriterenderer.sprite == walkdown1 || spriterenderer.sprite == walkdown2 || spriterenderer.sprite == walkdown3 || spriterenderer.sprite == walkdown4)
                    {
                        spriterenderer.sprite = walkdown1;
                    }
                    else if (spriterenderer.sprite == outofbed4)
                    {
                        spriterenderer.sprite = walkleft1;
                    }
                    else
                    {
                        spriterenderer.sprite = walkup1;
                    }
                }
            }

            
        }
    }

    public void walkright()
    {
        switch (check)
        {
            case 1:
                spriterenderer.sprite = walkright1;
                break;
            case 2:
                spriterenderer.sprite = walkright2;
                break;
            case 3:
                spriterenderer.sprite = walkright3;
                break;
            case 4:
                spriterenderer.sprite = walkright4;
                animinplay = false;
                break;
        }
    }

    public void walkleft()
    {
        switch (check)
        {
            case 1:
                spriterenderer.sprite = walkleft1;
                break;
            case 2:
                spriterenderer.sprite = walkleft2;
                break;
            case 3:
                spriterenderer.sprite = walkleft3;
                break;
            case 4:
                spriterenderer.sprite = walkleft4;
                animinplay = false;
                break;
        }
    }

    public void walkup()
    {
        switch (check)
        {
            case 1:
                spriterenderer.sprite = walkup1;
                break;
            case 2:
                spriterenderer.sprite = walkup2;
                break;
            case 3:
                spriterenderer.sprite = walkup3;
                break;
            case 4:
                spriterenderer.sprite = walkup4;
                animinplay = false;
                break;
        }
    }

    public void walkdown()
    {
        switch (check)
        {
            case 1:
                spriterenderer.sprite = walkdown1;
                break;
            case 2:
                spriterenderer.sprite = walkdown2;
                break;
            case 3:
                spriterenderer.sprite = walkdown3;
                break;
            case 4:
                spriterenderer.sprite = walkdown4;
                animinplay = false;
                break;
        }
    }
    public void getoutofbed()
    {
            switch (check)
            {
                case 1:
                    spriterenderer.sprite = outofbed1;
                    break;
                case 2:
                    spriterenderer.sprite = outofbed2;
                    break;
                case 3:
                    spriterenderer.sprite = outofbed3;
                    break;
                case 4:
                    spriterenderer.sprite = outofbed4;
                    animinplay = false;
                    playoutofbedanim = false;
                    showtext = true;
                    walktime = 1.0f;
                    break;
            }        
    }
}
