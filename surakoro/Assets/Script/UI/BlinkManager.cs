//------------------------------------------------------------//
// UIの点滅管理クラス
//                                          Yutaro Ono.
//-----------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkManager : MonoBehaviour
{
    // 点滅する速度
    public float blinkSpeed = 0.5f;

    // アルファ値の更新に用いるタイマー
    private float mTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 時間を更新
        mTime += Time.deltaTime * 5.0f * blinkSpeed;
    }


    // カラーのアルファ値を返す
    public Color GetAlphaColor(Color in_color)
    {
        // アルファ値を更新
        in_color.a = Mathf.Sin(mTime) * 0.5f + 0.5f;

        return in_color;
    }
}
