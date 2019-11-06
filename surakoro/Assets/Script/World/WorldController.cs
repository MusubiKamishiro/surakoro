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

    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerVal = Input.GetAxis("L_R_Trigger");

        

        // トリガーの入力が何もない状態ならIdle
        if (triggerVal == 0.0f)
        {
            mAnim.SetFloat("Trigger", 0.0f);
        }

        // 右トリガー入力状態なら時計回り回転アニメを開始
        if (triggerVal >= 0.1f)
        {
            mAnim.SetFloat("Trigger", triggerVal);
            Debug.Log("フィールド:右回転状態");
            Debug.Log("Trigger;" + triggerVal);

        }

        // 左トリガー入力状態なら反時計回り回転アニメを開始
        if (triggerVal <= -0.1f)
        {
            mAnim.SetFloat("Trigger", triggerVal);
            Debug.Log("フィールド:左回転状態");
            Debug.Log("Trigger;" + triggerVal);
        }

    }
}
