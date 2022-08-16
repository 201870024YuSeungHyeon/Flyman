using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletprefab;
    public float spawnRateMin; //�ּ� ź�� ���� �ð�
    public float spawnRateMax; //�ִ� ���� �ð�

    private float spawnRate; //����ؼ� �Ѿ��� ������ �� �ְ� �ð��� �Ǻ��ϴ� ����
    private float timeAfterSpawn;//����ؼ� �Ѿ��� ������ �� �ְ� �ð��� �Ǻ��ϴ� ����
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

            // Ÿ�� �������� �ٰ���
            bullet.transform.position += dir * 10 * Time.deltaTime;

            // Ÿ�� �������� ȸ����
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
