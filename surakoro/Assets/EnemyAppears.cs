using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppears : MonoBehaviour
{
    [SerializeField]
    GameObject enemyAppearsBox;

    GameObject obj;
    // Use this for initialization
    void Start()
    {
        // CubeプレハブをGameObject型で取得
        obj = (GameObject)Resources.Load("EnemyBox");
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, enemyAppearsBox.transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }

}