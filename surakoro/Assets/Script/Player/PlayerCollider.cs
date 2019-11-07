using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
	public enum EnemyColor
	{
		Red = 0,
		Brue,
		Green,
		Yellow,
		max
	};

	private EnemyColor oldEnemyColor = EnemyColor.max;    // 最後に食べた敵の色
	public int totalEatNum = 0;		// 敵を食べた総数
	private int combo = 0;				// コンボ, 同じ色が連続で消えた場合
	public const int addScore = 100;	// 加算スコア
	private List<bool> wallBreakFlag = new List<bool>();
	private int wallNum = 5;
    [SerializeField]
    CameraMng cameraMng;

    Score score = new Score();

	// 各種ゲッター
	public int GetTotalEatNum()
	{
		return totalEatNum;
	}
	public int GetCombo()
	{
		return combo;
	}
	public int GetWallNum()
	{
		return wallNum;
	}
	public EnemyColor GetEnemyColor()
	{
		return oldEnemyColor;
	}

	// 当たった瞬間
	private void OnCollisionEnter(Collision collision)
	{
		EatEnemy(collision);
	}
	// 当たってる間
	private void OnCollisionStay(Collision collision)
	{
		for (int i = 0; i < wallNum; ++i)
		{
			if (wallBreakFlag[i])
			{
                string mWallName = "Wall" + (i + 1).ToString();

                if (collision.gameObject.CompareTag(mWallName))
                {
                    GetComponent<AudioSource>().PlayOneShot(GetComponent<Sound>().GetSE(1));
                    collision.rigidbody.isKinematic = false;
                    collision.rigidbody.AddForceAtPosition(new Vector3(0, 0, Random.Range(-100, -1000) * (i*250)), new Vector3(0, 0, 0));
                }
            }
		}
	}

	
	// 敵を食べて得点を得る
	void EatEnemy(Collision collision)
	{
		for (int i = 0; i < (int)EnemyColor.max; ++i)
		{
			EnemyColor mEnemyColor = (EnemyColor)i;

			if (collision.gameObject.CompareTag(mEnemyColor.ToString()))
			{
				if (oldEnemyColor == mEnemyColor)
				{
					++combo;
					score.Add(addScore * combo);
				}
				else
				{
					oldEnemyColor = mEnemyColor;
					combo = 1;
					score.Add(addScore);
				}
				++totalEatNum;
                GetComponent<AudioSource>().PlayOneShot(GetComponent<Sound>().GetSE(2));
                Debug.Log(mEnemyColor.ToString() + "と接触");
				// Destroy(collision.gameObject);
			}
		}
		Debug.Log(combo + "コンボ");
		Debug.Log("敵を食べた数：" + totalEatNum);
	}

	void Start()
	{
		for (int i = 0; i < wallNum; ++i)
		{
			wallBreakFlag.Add(false);
		}
	}

	// Update is called once per frame
	void Update()
	{
		// 自機の巨大化状況で壁を吹き飛ばす
		Player mP = Player.FindObjectOfType<Player>();
		for (int i = 0; i < wallNum; ++i)
		{
			if(!mP.GetGiantFlag(i))
			{
				wallBreakFlag[i] = true;
               // cameraMng.ZoomOut(i);
			}
		}
	}
}
