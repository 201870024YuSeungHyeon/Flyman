using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform sPoint;
    public float timeBetweenShots;

    private float shotTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(bullet, sPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));

                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
