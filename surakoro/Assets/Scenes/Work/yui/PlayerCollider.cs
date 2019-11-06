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
	private int totalEatNum = 0;			// 敵を食べた総数
	private int combo = 0;				// コンボ, 同じ色が連続で消えた場合
	public const int addScore = 100;	// 加算スコア
	private List<bool> wallBreakFlag = new List<bool>();
	private int wallNum = 5;

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
				
					collision.rigidbody.isKinematic = false;
					collision.rigidbody.AddForceAtPosition(new Vector3(0, 0, Random.Range(-100, -1000)), new Vector3(0, 0, 0));
				}
			}
		}
	}

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
				Destroy(collision.gameObject);
				Debug.Log(mEnemyColor.ToString() + "と接触");
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
		for(int i = 0; i < wallNum; ++i)
		{
			if (transform.localScale.x >= (Player.FindObjectOfType<Player>().GetGrowingSize().x * (i + 1)))
			{
				wallBreakFlag[i] = true;
			}
		}
	}
}
