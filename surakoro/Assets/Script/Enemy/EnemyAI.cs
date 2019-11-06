//------------------------------------------------------------//
// エネミーのAI
//                                              Yutaro Ono.
//-----------------------------------------------------------//
// 優先度低のため保留
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // エネミーのAnimator取得
    private Animator mAnim;


    // エネミーの移動制御用タイマー
    float moveTimer;

    // 接地状態か調べるためのCharacterController
    private CharacterController charaCtrl;


    // Start is called before the first frame update
    void Start()
    {
        // Animator取得
        mAnim = GetComponent<Animator>();
        // CharacterController取得
        charaCtrl = GetComponent<CharacterController>();

        moveTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if(charaCtrl.isGrounded == false)
        {
            mAnim.enabled = false;
        }

        if(moveTimer <= 5.0f && charaCtrl.isGrounded)
        {
            mAnim.enabled = true;

            float rand = Random.Range(-1.0f, 1.0f);

            // ランダムでアニメーション設定
            mAnim.SetFloat("Move", rand);

            // タイマー初期化
            moveTimer = 0.0f;

        }



        moveTimer += Time.deltaTime;
    }
}
