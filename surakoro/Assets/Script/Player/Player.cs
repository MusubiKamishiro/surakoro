using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    private float speed = 1.5f;     // デバッグ用のプレイヤー移動速度
    private Vector3 growingSize = new Vector3(20, 20, 0);	// 敵を食べて大きくなるサイズ
	private List<bool> giantFlag = new List<bool>();
	private List<int> wallBreakCounts = new List<int>();
    private float secondCount = 0;


    public Vector3 GetGrowingSize()
	{
		return growingSize;
	}

    public bool GetGiantFlag(int i)
    {
        return giantFlag[i];
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerCollider pc = FindObjectOfType<PlayerCollider>();
        for (int i = 0; i < pc.GetWallNum(); ++i)
        {
            giantFlag.Add(true);
            wallBreakCounts.Add((i + 1) * 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 特定の大きさになったら壁を破壊する
        PlayerCollider pc = FindObjectOfType<PlayerCollider>();
        for (int i = 0; i < pc.GetWallNum(); ++i)
        {
            if (pc.GetTotalEatNum() > wallBreakCounts[i])
            {
                if (giantFlag[i])
                {
                    Giant(i);
                }
            }
        }
    }

    void Giant(int count)
    {
        sound.PlayWithoutOverlap(0);
        transform.localScale += growingSize / 60;
        if (secondCount > 1)
        {
            giantFlag[count] = false;
            growingSize *= 2;
            secondCount = 0;
        }
        secondCount += Time.deltaTime;
    }
}
