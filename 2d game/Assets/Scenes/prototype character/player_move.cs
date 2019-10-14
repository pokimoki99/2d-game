using System.Collections;
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
    public Text debugText;


    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = player.GetComponent<Rigidbody2D>();
    }

    private void RunCharacter(float horizontalInput)
    {
        //move player mobile
        characterBody.AddForce(new Vector2(horizontalInput * playerSpeed * Time.deltaTime, 0));
        Debug.Log("running");
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
        //int i = 0;
        ////loop over every touch found
        //while (i < Input.touchCount)
        //{
        //    Touch myTouch = Input.GetTouch(i);
        //    myTouch.phase = TouchPhase.Began;
        //    /*if (Input.GetTouch(i).position.x>ScreenWidth/2)
        //    {
        //        //move right
        //        RunCharacter(10.0f);
        //        PlayerMove();

        //    }*/
        //    if (myTouch.phase == TouchPhase.Began)
        //    {
        //        RunCharacter(10.0f);
        //        Debug.Log("running");
        //    }
        //    ++i;
        //    Debug.Log("touch");
        //}
        foreach (Touch touch in Input.touches)
        {
            debugText.text += "I see a touch!\n";
            //if (touch.phase == TouchPhase.Began)
            {
                //RunCharacter(1000.0f);
                Debug.Log("touch");
                debugText.text += "Last touch was in the began phase\n";
            }
            Debug.Log("touch");
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
                Debug.Log("jump");
                debugText.text += "Last touch was in the began phase\n";
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
        //animations


        //player direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
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

        if (other.gameObject.tag.Equals("mine"))
        {
            damage = true;

            Debug.Log("I GOT DAMAGED");
        }
    }
}
