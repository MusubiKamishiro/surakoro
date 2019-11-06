using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
	private int waitSecond = 3;		// スタートまでのカウントダウン
	private int startSecond = 1;	// スタートの文字表示時間
	public int gameSecond = 120;	// メインゲームを遊べる時間
	private int finishSecond = 2;	// 終了の文字表示時間
	private int stackSecond = 0;

	public bool countFlag = true;
	public bool startFlag = true;
	private bool gameFlag = true;
	private bool finishFlag = true;


    // Start is called before the first frame update
    void Start()
    {
		stackSecond = waitSecond;
    }

    // Update is called once per frame
    void Update()
    {
		if (countFlag)
		{
			Debug.Log("スタートまで：" + (stackSecond - (int)Time.time));
			if (Time.time > stackSecond)
			{
				countFlag = false;
				stackSecond += startSecond;
			}
		}
		else if(startFlag)
		{
			Debug.Log("スタート!!");
			if (Time.time > stackSecond)
			{
				startFlag = false;
				stackSecond += gameSecond;
			}
		}
		else if(gameFlag)
		{
			Debug.Log("ゲーム終了まで：" + (stackSecond - (int)Time.time));
			if (Time.time > stackSecond)
			{
				gameFlag = false;
				stackSecond += finishSecond;
			}
		}
		else if(finishFlag)
		{
			Debug.Log("終了～");
			if (Time.time > stackSecond)
			{
				SceneManager.LoadScene("ResultScene 1");
			}
		}
	}

	// ゲームの残り時間の取得
	public int GetCountSecond()
	{
		int mGameSecond = stackSecond - (int)Time.time;
		if(mGameSecond < 0)
		{
			return 0;
		}
		return mGameSecond;
	}
}
