//---------------------------------------------------------------//
// スコア表示スクリプト
//                                       Yutaro Ono.
//--------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // スコアに表示する値(scoreObjから取得)
    //[SerializeField]
   private Score score;

    // スコアを表示するTextオブジェクト
    [SerializeField]
    GameObject displayObj;

    // スコアのアニメーションに使う倍率
    private float mMagnif;


    Score mScore;

    // Start is called before the first frame update
    void Start()
    {
        //// スコアを保存しているオブジェクトを検索
        //GameObject scoreObj = GameObject.Find("");

        //// スコアオブジェクトからスコアを取得
        //score = scoreObj.GetScore();

        // スコアを表示するオブジェクトの取得
        //displayObj = GameObject.Find("");

        score = FindObjectOfType<Score>();
        mMagnif = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // スコアのtextオブジェクトからTextコンポーネントを取得
        Text scoreText = displayObj.GetComponent<Text>();

        scoreText.text = "Score:" + score.GetScore();

        
    }
}
