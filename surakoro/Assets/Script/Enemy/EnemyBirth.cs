﻿//*********************
// EnemyBirth.cs
// EnemyBirth専用
//*********************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirth : MonoBehaviour
{
    float count;        // 敵が出てくる間の時間

    [SerializeField]
    GameObject enemy;   // 箱から出現させたい敵

    [SerializeField]
    float countMax;     // 敵が出てくる間の時間（上限）

    [SerializeField]
    int allEnemyMax;    // 全体で敵が出てくる数の上限
    bool spawnFlag = true;
    

    List<GameObject> enemyPrefab = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    void Update()
    {
        // 出るかどうかのためし
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    // Cubeプレハブを元に、インスタンスを生成、
        //    Instantiate(enemy, this.transform.position, Quaternion.identity);
        //}
        //敵が上限にいってないか
        if(GameObject.FindGameObjectsWithTag("Enemy").Length < allEnemyMax)
        {
            count += Time.deltaTime;
        }
        // カウントでどれくらいの感覚で出てくるか
        if(count >= countMax)
        {
            if (spawnFlag)
            {
                // Cubeプレハブを元に、インスタンスを生成
                var e =Instantiate(enemy, this.transform.position, Quaternion.identity);
                enemyPrefab.Add(e);
                count = 0;
            }
            
        }
    }
    public float GetCountMax()
    {
        return countMax;
    }
    public int GetEnemyMax()
    {
        return allEnemyMax;
    }

    public void SetCountMax(float idx)
    {
        countMax = idx;
    }
    public void SetEnemyMax(int idx)
    {
        allEnemyMax = idx;
    }

    public void SetSpawnFlag(bool flag)
    {
        spawnFlag = flag;
    }

    public void DestroyPrefab()
    {
        foreach( GameObject obj in enemyPrefab)
        {

            if (obj == null)
            {
                continue;
            }
            if (obj.GetComponent<EnemyDieOrLife>().GetDieFlag())
            {
                continue;
            }
            obj.GetComponent<SphereCollider>().enabled = false;
            var objPos = Camera.main.WorldToScreenPoint(obj.transform.position);
            if (objPos.y > Screen.height)
            {
                Debug.Log("敵消す");
                Destroy(obj,0.1f);
            }
        }
    }
}