using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletprefab;
    public float spawnRateMin; //�ּ� ź�� ���� �ð�
    public float spawnRateMax; //�ִ� ���� �ð�

    private Transform target; //ź���� ���� Ÿ��
    private float spawnRate; //����ؼ� �Ѿ��� ������ �� �ְ� �ð��� �Ǻ��ϴ� ����
    private float timeAfterSpawn;//����ؼ� �Ѿ��� ������ �� �ְ� �ð��� �Ǻ��ϴ� ����


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
