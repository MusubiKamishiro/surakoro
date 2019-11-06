//-------------------------------------------------------------//
// Imageの点滅スクリプト
//                                  Yutaro Ono.
//------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour
{
    // イメージ格納用
    [SerializeField]
    Image imgObj;

    // 点滅クラス
    BlinkManager blink;

    // Start is called before the first frame update
    void Start()
    {
        imgObj = GetComponent<Image>();

        var blinkObj = GameObject.Find("BlinkManager");
        // マネージャーを取得
        blink = blinkObj.GetComponent<BlinkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        imgObj.color = blink.GetAlphaColor(imgObj.color);
    }
}
