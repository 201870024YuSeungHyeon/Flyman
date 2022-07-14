using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;
    public GameObject[] BlockPrefab;

    [SerializeField] Transform tfBlockAppear = null; //�� ���� ��ġ ������Ʈ




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d / bpm) //�� ���� �ӵ� �� ���� �����ǰ� ��
        {
            int blockIndex = Random.Range(0, BlockPrefab.Length);
            GameObject block = Instantiate(BlockPrefab[blockIndex], tfBlockAppear.position, Quaternion.identity);
            block.transform.SetParent(this.transform);

            currentTime -= 90d / bpm;
        }
    }
}
