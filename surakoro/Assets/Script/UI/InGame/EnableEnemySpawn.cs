using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemySpawn : MonoBehaviour
{
    public GameObject enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawn = GameObject.Find("Wall1_Outer 1/EnemySpawn");
        enemySpawn.SetActive(false);
    }

    public void SetFirstSpawn()
    {
        enemySpawn.SetActive(true);
    }
}
