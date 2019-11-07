//---------------------------------------------------------//
// フェード処理用スクリプト
//                                Yutaro Ono.
//--------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image fadeImg;

    // カラーのアルファ値調整用
    public float alfa;

    // 加算スピード
    public float addSpeed = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject fadeObj = GameObject.Find("FadeImage");

        // Colorコンポーネント取得
        fadeImg = fadeObj.GetComponent<Image>();

        alfa = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // アルファ値を更新し、1.0に達したらtrueを返す
    public bool FadeIn(float in_Time)
    {
        // アルファ値を更新
        alfa += Time.deltaTime / in_Time;

        // カラーを更新
        fadeImg.color = new Color(255, 255, 255, alfa);

        if (alfa >= 1.0)
        {
            return true;
        }

        return false;
    }

    // アルファ値を更新し、0に達したらtrueを返す
    public bool FadeOut(float in_Time)
    {
        alfa -= Time.deltaTime / in_Time;

        // カラーを更新
        fadeImg.color = new Color(255, 255, 255, alfa);

        if(alfa <= 0.0f)
        {
            return true;
        }

        return false;
    }
}
