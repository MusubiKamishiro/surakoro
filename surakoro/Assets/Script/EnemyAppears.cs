using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppears : MonoBehaviour
{
    int count;          // 敵が出てくる間の時間

    [SerializeField]
    GameObject enemy;   // 箱から出現させたい敵

    [SerializeField]
    int count_max;      // 敵が出てくる間の時間（上限）

    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    void Update()
    {
        count++;
        // 出るかどうかのためし
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
        // カウントでどれくらいの感覚で出てくるか
        if(count >= count_max)
        {
            // Cubeプレハブを元に、インスタンスを生成
            Instantiate(enemy, transform.position, Quaternion.identity);
            count = 0;
        }
    }

}