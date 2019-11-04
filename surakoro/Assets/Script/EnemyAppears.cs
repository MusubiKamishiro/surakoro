using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppears : MonoBehaviour
{
    [SerializeField]
    GameObject enemyAppearsBox;

    GameObject enemy;
    // Use this for initialization
    void Start()
    {
        // CubeプレハブをGameObject型で取得
        enemy = (GameObject)Resources.Load("EnemyBox");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(enemy, enemyAppearsBox.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }

}