//***************************************
// CapSensor.cs
// sensorにつけるプログラム
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapSensor : MonoBehaviour
{
    // 外で見るフラグたち
    private bool openFlag;      // 蓋が開くフラグ（蓋で使う）
    private bool bonusFlag;     // ボーナスがもらえるフラグ（考え中）

    // ゲッター/セッター
    public bool OpenFlag
    {
        get { return openFlag; }
        private set { openFlag = value; }
    }
    public bool BonusFlag
    {
        get { return bonusFlag; }
        private set { bonusFlag = value; }
    }

    // ここでしか使わない変数
    private string enemyTag;        // 落ちてきた１匹目の敵のタグを補完する
    private int enemyTagNum;        // そのタグを持ってる敵の数

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        openFlag = false;
        bonusFlag = false;
        enemyTag = "";
        enemyTagNum = 0;
    }

    // パネルに触れたとき
    void OnCollisionEnter(Collision collision)
    {
        // 敵が１匹以上たまってるとき
        if (enemyTagNum >= 1)
        {
            // コンボの対象と同じだったら
            if (collision.gameObject.tag == enemyTag)
            {
                // コンボアップ
                enemyTagNum++;
                // コンボが５コンボつながったら
                if (enemyTagNum >= 5)
                {
                    // 蓋が開いてコンボ終わり
                    openFlag = true;
                    // bonusが入る
                    bonusFlag = true;
                    // 初期化
                    enemyTagNum = 0;
                }
            }
            else
            {
                // 蓋が開いてコンボ終わり
                openFlag = true;
                // 初期化
                enemyTagNum = 0;
            }
        }
        // 敵がまだいないとき
        else
        {
            // 敵の数を増やす
            enemyTagNum++;
            // コンボの対象を選択する
            enemyTag = collision.gameObject.tag;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 処理なし
    }
}
