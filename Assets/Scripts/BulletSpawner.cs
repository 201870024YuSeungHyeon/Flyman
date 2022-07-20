using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletprefab;
    public float spawnRateMin; //최소 탄알 생성 시간
    public float spawnRateMax; //최대 생성 시간

    private Transform target; //탄알이 향할 타겟
    private float spawnRate; //계속해서 총알이 생성될 수 있게 시간을 판별하는 변수
    private float timeAfterSpawn;//계속해서 총알이 생성될 수 있게 시간을 판별하는 변수


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
