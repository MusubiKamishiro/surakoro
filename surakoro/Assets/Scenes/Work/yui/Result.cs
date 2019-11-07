using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
	public GameObject player;
	public GameObject enemyRed;
	public GameObject enemyGreen;
	public int redCount;
	public int greenCount;
	private int totalEatCount;  // 食べた合計スライム数

	bool flag = true;

	float count;
	float countMax = 1.0f;

	// Start is called before the first frame update
	void Start()
    {
		Ibukuro ibukuro = FindObjectOfType<Ibukuro>();
		//redCount = ibukuro.EnemyScoreGet(0);
		//greenCount = ibukuro.EnemyScoreGet(2);
		totalEatCount = redCount + greenCount;
	}

	// Update is called once per frame
	void Update()
    {
		if ((redCount > 0) || (greenCount > 0))
		{
			FallEnemy();
		}
		else
		{
			if(flag)
			{
				//Instantiate(player, this.transform.position, Quaternion.identity);
				flag = false;
			}
			
			Debug.Log("合計スライム：" + totalEatCount);

			// ボタンを押したらシーン切り替え
			if (Input.GetKey("joystick button 0"))
			{
				SceneManager.LoadScene("TitleScene 1");
			}
		}

		count += Time.deltaTime;
	}

	// 最初に敵が落ちてくる
	void FallEnemy()
	{
		if (count >= countMax)
		{
			if (redCount > 0)
			{
				Vector3 pos = new Vector3(Random.Range(-20, 20), Random.Range(10, 20), Random.Range(-10, 10));
				Instantiate(enemyRed, this.transform.position + pos, Quaternion.identity);
				--redCount;
			}

			if (greenCount > 0)
			{
				Vector3 pos = new Vector3(Random.Range(-20, 20), Random.Range(10, 20), Random.Range(-10, 10));
				Instantiate(enemyGreen, this.transform.position + pos, Quaternion.identity);
				--greenCount;
			}
			count = 0;
			countMax *= 0.9f;
		}
	}
}
