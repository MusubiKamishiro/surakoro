using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirthMng : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyBirthGroup;
    private bool[] normalValueFlag;
    [SerializeField]
    Player player;
    private int slowSpawnRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        normalValueFlag = new bool[enemyBirthGroup.Length];
        normalValueFlag[0] = false;

        //enemyBirthGroup = new GameObject[wallNum];
        for (int j = 1; j < enemyBirthGroup.Length; j++)
        {
            normalValueFlag[j] = false;


            for (int i = 0; i < enemyBirthGroup[j].transform.childCount; i++)
            {

                enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().SetCountMax(enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().GetCountMax() * slowSpawnRate);
                enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().SetEnemyMax(enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().GetEnemyMax() / 2);
                if (j + 1 < enemyBirthGroup.Length)
                {
                    enemyBirthGroup[j + 1].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        StageInit();
    }

    void StageInit()
    {
        for (int i = 1; i < enemyBirthGroup.Length; ++i)
        {
            if (!player.GetGiantFlag(i - 1) && !normalValueFlag[i])
            {
                for (int j = 0; j < enemyBirthGroup[i].transform.childCount; j++)
                {
                    enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().SetCountMax(enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().GetCountMax() / slowSpawnRate);
                    enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().SetEnemyMax(enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().GetEnemyMax() * 2);
                }
                if (i + 1 < enemyBirthGroup.Length)
                {
                    enemyBirthGroup[i + 1].SetActive(true);
                }
                enemyBirthGroup[i - 1].SetActive(false);
                normalValueFlag[i] = true;

            }

            //else
            //{
            //    level[i]
            //}
        }
    }
}
