using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneManager : MonoBehaviour
{
    // ゲームのステート
    public enum GAME_STATE
    {
        TUTORIAL = 0,
        COUNTDOWN,
        IN_GAME,
        GAME_END
    }

    // 現在のゲームステート格納
    public GAME_STATE stateInfo;

    // カウントダウン
    public GameObject countObj;


    // InputManager
    InputManager mInput;

    // Start is called before the first frame update
    void Start()
    {
        // チュートリアルのステートを保管
        stateInfo = GAME_STATE.TUTORIAL;

        // カウントダウンオブジェクト取得
        countObj = GameObject.Find("CountDown");
        countObj.SetActive(false);

        // InputManagerオブジェクトをFind
        GameObject inputObj = GameObject.Find("InputManager");
        mInput = inputObj.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // チュートリアル処理
        if(stateInfo == GAME_STATE.TUTORIAL)
        {
            Tutorial();
        }

        // カウントダウン処理
        if(stateInfo == GAME_STATE.COUNTDOWN)
        {
            CountDown();
        }

        // インゲーム処理
        if(stateInfo == GAME_STATE.IN_GAME)
        {
            InGame();
        }

        // 終了処理
        if(stateInfo == GAME_STATE.GAME_END)
        {
            GameEnd();
        }


    }

    // チュートリアル処理
    void Tutorial()
    {
        // 決定ボタンが押されたらカウントダウン処理開始
        if(mInput.GetEnter() == true)
        {
            countObj.SetActive(true);
            stateInfo = GAME_STATE.COUNTDOWN; 
        }
    }

    void CountDown()
    {

    }

    void InGame()
    {

    }

    void GameEnd()
    {

    }
}
