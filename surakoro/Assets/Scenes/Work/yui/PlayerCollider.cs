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
		max
	};

	public int totalEatNum = 0;			// 敵を食べた総数
	public EnemyColor oldEnemyColor = EnemyColor.max;    // 最後に食べた敵の色
	public int score = 0;				// スコア
	public int combo = 0;				// コンボ, 同じ色が連続で消えた場合
	public const int addScore = 100;	// 加算スコア
	private bool wall1BreakFlag = false;
	private Vector3 scale = new Vector3(20, 20, 0);     // 敵を食べて大きくなるサイズ;

	// 各種ゲッター
	public int GetTotalEatNum()
	{
		return totalEatNum;
	}
	public int GetScore()
	{
		return score;
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
		if (collision.gameObject.CompareTag("wall1"))
		{
			if (wall1BreakFlag)
			{
				//Destroy(collision.gameObject);
				collision.rigidbody.isKinematic = false;
				//Vector3 mLocalScale = collision.gameObject.transform.localScale;
				//Vector3 mPos = new Vector3(Random.Range(0, mLocalScale.x), Random.Range(0, mLocalScale.y), Random.Range(0, mLocalScale.z));
				collision.rigidbody.AddForceAtPosition(new Vector3(0, 0, Random.Range(-100, -1000)), new Vector3(0, 0, 0));
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
					score += addScore * combo;
				}
				else
				{
					oldEnemyColor = mEnemyColor;
					score += addScore;
					combo = 1;
				}
				++totalEatNum;
				Destroy(collision.gameObject);
				Debug.Log(mEnemyColor.ToString() + "と接触");
			}
		}

		Debug.Log("得点：" + score);
		Debug.Log(combo + "コンボ");
		Debug.Log("敵を食べた数：" + totalEatNum);
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.x >= scale.x)
		{
			wall1BreakFlag = true;
		}
	}
}
