using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody2D rigid;

    public float moveSpeed = 1f;
    public float jumpPower = 1f;
    public float maxSpeed = 1f;

    bool isJumping = false;
    public Gaugebar gb;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping) // ����
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
                gameObject.layer = 7;
            }
            else if (isJumping && rigid.gravityScale != 0)
            {
                OnBooster(true);
            }
            else if (isJumping && rigid.gravityScale == 0)
                OnBooster(false);
        }

        if (gb.CurrentValue <= 0)
        {
            OnBooster(false);
        }

        if (rigid.velocity.x > maxSpeed)  //���������� �̵� (+) , �ִ� �ӷ��� ������ 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //�ش� ������Ʈ�� �ӷ��� maxSpeed 
        else if (rigid.velocity.x < maxSpeed * (-1)) // �������� �̵� (-) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        else if ((rigid.velocity.y < maxSpeed * (-1)) && rigid.gravityScale == 0) // �ν��� ���� ���� �ӵ� ���� �� �ӵ� ����
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));
        else if ((rigid.velocity.y > maxSpeed) && rigid.gravityScale == 0)
            rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);

    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * moveSpeed, ForceMode2D.Impulse);
        if (rigid.gravityScale == 0)
        {
            float v = Input.GetAxisRaw("Vertical");
            rigid.AddForce(Vector2.up * v * moveSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.gameObject.CompareTag("Floor")) // ���󿡼� ���� ����
            {
                gameObject.layer = 6;
                gb.isValue = false;
                isJumping = false;
            }
        }
    }

    void OnBooster(bool A) // �ν���
    {
        if (A) // �ѱ�
        {
            rigid.velocity = new Vector2(0, 0);
            rigid.gravityScale = 0;
            gb.isValue = true;
        }
        else if (!A) // ����
        {
            rigid.gravityScale = 150;
        }
    }


}





























































