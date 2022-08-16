using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletprefab;
    public float spawnRateMin; //최소 탄알 생성 시간
    public float spawnRateMax; //최대 생성 시간

    private float spawnRate; //계속해서 총알이 생성될 수 있게 시간을 판별하는 변수
    private float timeAfterSpawn;//계속해서 총알이 생성될 수 있게 시간을 판별하는 변수
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        Vector3 l_vector = target.transform.position - transform.position;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.LookRotation(l_vector).normalized;
            Vector3 dir = target.transform.position - bullet.transform.position;

            // 타겟 방향으로 다가감
            bullet.transform.position += dir * 10 * Time.deltaTime;

            // 타겟 방향으로 회전함
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
