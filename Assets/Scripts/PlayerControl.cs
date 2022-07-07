using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D rigid;

    public float moveSpeed = 1f;
    public float jumpPower = 1f;

    bool isJumping = false;
   
    bool canjump = false;

 
   
   
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject.layer == 7 && rigid.gravityScale != 0)
            {
                rigid.gravityScale = 0;
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else if (rigid.gravityScale == 0)
            {
                rigid.gravityScale = 150;
            }
        }

    }

    void FixedUpdate()
    {
        FloorMove();
        Jump();
        AirMove();
    }

   void AirMove()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (gameObject.layer == 7)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                moveVelocity = new Vector2(-1,1);
            }
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                moveVelocity = new Vector2(-1, -1);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                moveVelocity = new Vector2(1, 1);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                moveVelocity = new Vector2(1, -1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveVelocity = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveVelocity = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveVelocity = Vector2.down;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                moveVelocity = Vector2.up;
            }
            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
        
    }

    void Jump()
    {
        if(gameObject.layer == 7) {
            isJumping = false;
        }
        if (!canjump)
        {
            if (!isJumping) 
                return;
            gameObject.layer = 7;
            
        
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        else
        {
            return;
        }
    }


    void FloorMove()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (gameObject.layer == 6)
        {

            if (Input.GetKey(KeyCode.A))
            {
                moveVelocity = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveVelocity = Vector2.right;
            }

            transform.position += moveVelocity * moveSpeed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                gameObject.layer = 6;
                rigid.gravityScale = 150;
            }
        }
    }
   


}
