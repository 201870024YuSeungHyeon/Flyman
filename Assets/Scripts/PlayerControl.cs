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
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            gameObject.layer = 7;
        }
        if (rigid.velocity.x > maxSpeed)  //���������� �̵� (+) , �ִ� �ӷ��� ������ 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //�ش� ������Ʈ�� �ӷ��� maxSpeed 

        //Max speed left
        else if (rigid.velocity.x < maxSpeed * (-1)) // �������� �̵� (-) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * moveSpeed, ForceMode2D.Impulse);
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



}