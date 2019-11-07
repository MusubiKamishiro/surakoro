//-----------------------------------------------------------------------//
// ゲーム開始時のカウントダウンを再生する
//                                              Yutaro Ono.
//----------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameCountDown : MonoBehaviour
{
    // カウントダウンイメージ格納用
    [SerializeField]
    private GameObject countDownObj;

    // フェードマネージャ格納用
    [SerializeField]
    private GameObject fadeManager;
    // フェードスクリプト
    FadeScript fade;

    // カウントダウン用アニメーター取得
    public Animator countDownAnim;

    bool enable = false;


    // エネミーのスポーン地点
    public GameObject spawnpoint;


    // Start is called before the first frame update
    void Start()
    {
        countDownObj = GameObject.Find("CountDown");
        countDownAnim = countDownObj.GetComponent<Animator>();
        countDownObj.SetActive(false);


        // フェードマネージャを取得
        fadeManager = GameObject.Find("FadeManager");
        fade = fadeManager.GetComponent<FadeScript>();

        spawnpoint = GameObject.Find("Wall1_Outer 1/EnemySpawn");
        spawnpoint.SetActive(false);

        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        // フェードアウトが終わったらカウントダウン開始
        if(fade.FadeOut(5.0f))
        {
            if(enable == false)
            {
                countDownObj.SetActive(true);
                countDownAnim.SetTrigger("start");

                // スポーン開始
                spawnpoint.SetActive(true);

                enable = true;
            }

        }


    }
}
