//------------------------------------------------------------------//
// Input関連の処理管理クラス
//                                             Yutaro Ono.
//-----------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float triggerVal = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        triggerVal = Input.GetAxis("L_R_Trigger");
    }

    // Update is called once per frame
    void Update()
    {
        // LRトリガーの入力値を得る
        triggerVal = Input.GetAxis("L_R_Trigger");
    }

    // LRトリガーの現在の入力値を取得する
    public float GetTriggerVal()
    {
        return triggerVal;
    }

    // 決定ボタンの取得(A)
    public bool GetEnter()
    {
        return Input.GetButtonDown("Fire1");
    }

    // キャンセルボタンの取得(B)
    public bool GetCancel()
    {
        return Input.GetButtonDown("Fire2");
    }

}
