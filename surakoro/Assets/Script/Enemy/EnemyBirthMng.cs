using UnityEngine;

public class EnemyBirthMng : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyBirthGroup;
    [SerializeField]
    Player player;
    private bool[] revertValueFlag;
    [SerializeField]
    private float[] slowSpawnRate;
    [SerializeField]
    private int[] lowerEnemyMax;


    // Start is called before the first frame update
    void Start()
    {
        revertValueFlag = new bool[enemyBirthGroup.Length];
        revertValueFlag[0] = false;

        //enemyBirthGroup = new GameObject[wallNum];
        //第一ステージはそのまま
        for (int j = 1; j < enemyBirthGroup.Length; j++)
        {
            revertValueFlag[j] = false;

            for (int i = 0; i < enemyBirthGroup[j].transform.childCount; i++)
            {
                enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().SetCountMax(enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().GetCountMax() * slowSpawnRate[j]);
                enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().SetEnemyMax(enemyBirthGroup[j].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().GetEnemyMax() / lowerEnemyMax[j]);
                if (j + 1 < enemyBirthGroup.Length)
                {
                    //今と次のステージをtrueにするだけ
                    //例：1,2-> 2,3 -> 3,4
                    enemyBirthGroup[j + 1].transform.GetChild(i).gameObject.GetComponent<EnemyBirth>().SetSpawnFlag(false);
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        StageInit();
        for (int i = 0; i < enemyBirthGroup.Length;i++)
        {
            for (int j = 0; j < enemyBirthGroup[i].transform.childCount; j++)
            {
                if (!enemyBirthGroup[i].activeSelf)
                {
                    enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().DestroyPrefab();
                } 
            }
        }
    }

    void StageInit()
    {
        //第一ステージはそのまま
        for (int i = 1; i < enemyBirthGroup.Length; ++i)
        {
            if (!player.GetGiantFlag(i - 1) && !revertValueFlag[i])
            {
                for (int j = 0; j < enemyBirthGroup[i].transform.childCount; j++)
                {
                    enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().SetCountMax(enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().GetCountMax() / slowSpawnRate[i]);
                    enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().SetEnemyMax(enemyBirthGroup[i].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().GetEnemyMax() * lowerEnemyMax[i]);
                    if (i + 1 < enemyBirthGroup.Length)
                    {

                        enemyBirthGroup[i + 1].transform.GetChild(j).gameObject.GetComponent<EnemyBirth>().SetSpawnFlag(true);
                    }
                }
               
                enemyBirthGroup[i - 1].SetActive(false);
                revertValueFlag[i] = true;

            }
            //if (!player.GetGiantFlag(i))
            //{
            //    enemyBirthGroup[i].SetActive(false);
            //}

        }
    }
}
