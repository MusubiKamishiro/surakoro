//----------------------------------------------------------------------//
// インゲームのタイマーをテキストに描画するスクリプト
//                                                  Yutaro Ono.
//---------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    private GameTime mTime;

    [SerializeField]
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        // タイムマネージャー取得
        var timeManager = GameObject.Find("TimeManager");
        
        mTime = timeManager.GetComponent<GameTime>();

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 開始時カウントダウン時以外にカウントダウン処理を実行
        if(mTime.countFlag == false && mTime.startFlag == false)
        {
            text.text = "" + mTime.GetCountSecond();
        }


    }
}
