using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletspeed;
    private Rigidbody2D bulletrigid;

    // Start is called before the first frame update
    void Start()
    {
        bulletrigid = GetComponent<Rigidbody2D>();
        bulletrigid.velocity = transform.forward * bulletspeed;

        Destroy(gameObject, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
