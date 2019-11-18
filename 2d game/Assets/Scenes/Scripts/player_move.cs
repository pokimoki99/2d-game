﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight;
    public int PlayerJumpPower = 1250;
    private float moveX;

    public bool switched = false;
    public bool damage = false;

    private Rigidbody2D characterBody;
    private float ScreenWidth;
    public GameObject player;
    public GameObject tank;
    //public Text debugText;

    private Vector2 fp;
    private Vector2 lp;
    private float dragDistance;
    float timer = 30.0f;


    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = GetComponent<Rigidbody2D>();
        tank.SetActive(false);
    }

    private void RunCharacter(float horizontalInput)
    {
        //move player mobile
        characterBody.AddForce(new Vector2(horizontalInput * playerSpeed * Time.deltaTime, 0));
        //Debug.Log("running");
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

                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (lp.x > fp.x)
                    {
                        Debug.Log("right swipe");
                    }
                    else
                    {
                        Debug.Log("left swipe");
                    }
                }
                else
                {
                    if (lp.y > fp.y)
                    {
                        Debug.Log("up swipe");
                    }
                    else
                    {
                        Debug.Log("Down swipe");
                    }
                }
            }
            else
            {
                Debug.Log("tap");
            }
        }

        //foreach (Touch touch in Input.touches)
        //{
        //    debugText.text += "I see a touch!\n";

        //    Debug.Log("touch");
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Jump();
        //        Debug.Log("jump");
        //        debugText.text += "Last touch was in the began phase\n";
        //    }
        //}
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
        //animations


        //player direction
        //if (moveX < 0.0f && facingRight == false)
        //{
        //    FlipPlayer();
        //}
        //else if (moveX > 0.0f && facingRight == true)
        //{
        //    FlipPlayer();
        //}
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);


    }

    void Jump()
    {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJumpPower);

    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Detecc"))
        {
            switched = true;

            Debug.Log("I AM SWITCHED");
        }
        if (other.gameObject.name.Equals("Tank_power_up"))
        {
            timer = 10;
            player.SetActive(false);
            tank.SetActive(true);
            Debug.Log("collide with player");
        }


        if (other.gameObject.tag.Equals("mine"))
        {
            damage = true;
            Destroy(GameObject.Find("Mine(Clone)"));
            Debug.Log("I GOT DAMAGED");
        }
        if (other.gameObject.tag.Equals("enemy"))
        {
            damage = true;
            Destroy(GameObject.Find("enemy(Clone)"));
            Debug.Log("I GOT DAMAGED");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            player.SetActive(true);
            tank.SetActive(false);
            Debug.Log("collide with player");
            Debug.Log(timer);
        }

    }
}