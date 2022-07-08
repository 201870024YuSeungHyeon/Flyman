using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 8)
        {
            transform.localPosition += new Vector3(0, -1, 0) * 7 * Time.deltaTime;
        }
        else if(gameObject.layer == 9)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        Vector3 view = Camera.main.WorldToScreenPoint(transform.position);
        if (view.y < -70)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.layer = 9;
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
