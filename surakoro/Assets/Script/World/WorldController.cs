//-------------------------------------------------------------------------//
// ワールドの回転操作
//                                                     Yutaro Ono.
//------------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{

    // ワールドアニメーター格納
    private Animator mAnim;

    private InputManager mInput;

    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();

        // Scene上のInputManagerを検索し、スクリプトを取得
        var inputObj = GameObject.Find("InputManager");
        mInput = inputObj.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        // トリガーの入力が何もない状態ならIdle
        if (mInput.GetTriggerVal() == 0.0f)
        {
            mAnim.SetFloat("Trigger", 0.0f);
        }

        // 右トリガー入力状態なら時計回り回転アニメを開始
        if (mInput.GetTriggerVal() >= 0.1f)
        {
            mAnim.SetFloat("Trigger", mInput.GetTriggerVal());
            Debug.Log("フィールド:右回転状態");
            Debug.Log("Trigger;" + mInput.GetTriggerVal());

        }

        // 左トリガー入力状態なら反時計回り回転アニメを開始
        if (mInput.GetTriggerVal() <= -0.1f)
        {
            mAnim.SetFloat("Trigger", mInput.GetTriggerVal());
            Debug.Log("フィールド:左回転状態");
            Debug.Log("Trigger;" + mInput.GetTriggerVal());
        }

    }
}
