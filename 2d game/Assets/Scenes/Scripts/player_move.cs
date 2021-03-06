﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour
{
    //movement
    public int playerSpeed = 10;
    private bool facingRight;
    public int PlayerJumpPower = 1250;
    private float moveX;

    //touch mechanic
    private Vector2 fp;
    private Vector2 lp;
    private float dragDistanceH;
    float timer = 30.0f;

    //tap mechanic
    bool tapping = false;
    float tapTimer = 0f;
    public float maxTaps = 4.0f;


    //sliding mechanic
    bool sliding = false;
    float slideTimer = 0f;
    public float maxSlideTime = 1.0f;

    public bool damage = false;
    public bool heal = false;
    public bool bol = true;

    //objects
    private Rigidbody2D characterBody;
    public GameObject player;
    public GameObject tank;
    public Text debugText;

    Health hp;
    Score point;

    Object BulletRef;
    public bool fire = false;

    public GameObject healthCollider;

    [SerializeField]
    public Animator anim;




    void Start()
    {
        characterBody = GetComponent<Rigidbody2D>();
        tank.SetActive(false);
        dragDistanceH = Screen.height * 15 / 100; //dragDistance is 5% height of the screen
        BulletRef = Resources.Load("Bullet");
    }

    private void RunCharacter(float horizontalInput)
    {
        //move player mobile
        characterBody.AddForce(new Vector2(horizontalInput * playerSpeed * Time.deltaTime, 0));
    }

    public void MovePlayer(float moveAmount)
    {
        RunCharacter(moveAmount);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        RunCharacter(1000.0f);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                tapping = false;

                if (Mathf.Abs(lp.y - fp.y) > dragDistanceH)
                {
                    if (lp.x > fp.x)
                    {
                        debugText.text += "right swipe\n";
                        Debug.Log("right swipe");
                        bulletfire();
                    }
                    else
                    {
                        if (!sliding)
                        {
                            slideTimer = 0f;

                            anim.SetTrigger("isSliding");
                            print("Slide");
                            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                            healthCollider.GetComponent<CapsuleCollider2D>().enabled = false;
                            sliding = true;
                        }

                        if (sliding)
                        {
                            slideTimer += Time.deltaTime;
                            if (slideTimer > maxSlideTime)
                            {
                                sliding = false;
                                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                                healthCollider.GetComponent<CapsuleCollider2D>().enabled = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!tapping)
                {
                    tapTimer = 0f;
                    Jump();
                    Debug.Log("jump");
                    tapping = true;
                   
                }

            }
        }
        if (tapping)
        {
            tapTimer += Time.deltaTime;
            if (tapTimer > maxTaps)
            {
                tapping = false;
                tapTimer = 0;

            }
        }


    }
    private void FixedUpdate()
    {
#if Unity_Editor
        RunCharacter(input.GetAxis("Horizontal"));
#endif
    }

    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Slide") && !sliding)
        {
            slideTimer = 0f;

            anim.SetTrigger("isSliding");
            print("Slide");
            healthCollider.GetComponent<CapsuleCollider2D>().enabled = false;
            sliding = true;
        }
        if (sliding)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer>maxSlideTime)
            {
                sliding = false;
                healthCollider.GetComponent<CapsuleCollider2D>().enabled = true;
            }
        }
    }


    void Jump()
    {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);

    }
    public void bulletfire()
    {
        GameObject bullet = (GameObject)Instantiate(BulletRef);
        bullet.transform.position = new Vector3(transform.position.x + .4f, transform.position.y + .2f, -1f);
        fire = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.name.Equals("Tank_power_up"))
        {
            timer = 10;
            player.SetActive(false);
            tank.SetActive(true);
            tank.GetComponent<BoxCollider2D>().enabled = true ;
            Debug.Log("collide with player");
        }


        if (other.gameObject.tag.Equals("mine"))
        {
            damage = true;
            Destroy(GameObject.FindWithTag("mine"));
            Debug.Log("I GOT Mined");
        }
        if (other.gameObject.tag.Equals("enemy"))
        {
            damage = true;
            Destroy(GameObject.FindWithTag("enemy"));
            Debug.Log("I GOT DAMAGED");
        }
        if (other== GameObject.FindWithTag("enemy"))
        {
            damage = true;
            Destroy(GameObject.FindWithTag("enemy"));
            Debug.Log("I GOT DAMAGED");
        }

        if (other.gameObject.tag.Equals("HP_powerup"))
        {
            heal = true;
            Destroy(GameObject.FindWithTag("HP_powerup"));
            Debug.Log("I GOT healed");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            player.SetActive(true);
            tank.SetActive(false);
            tank.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("collide with player");
            Debug.Log(timer);
        }
        if (other.gameObject.name.Equals("Detecc"))
        {
            GameObject.FindWithTag("Respawn").GetComponent<BoxCollider2D>().enabled = false;
        }


    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, hp, point);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        hp.health = data.health;
        point.savedata = data.score;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];

    }

}
