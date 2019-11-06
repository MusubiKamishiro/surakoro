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

    // エネミーのRigidBody格納用
    private Rigidbody mRb;


    // エネミーの移動制御用タイマー
    float moveTimer;


    // Start is called before the first frame update
    void Start()
    {
        // RigidBody取得
        mRb = GetComponent<Rigidbody>();

        moveTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {


        // タイマーが5秒以上になったらエネミーを移動させる
        if (moveTimer >= 3.0f)
        {
            // エネミーの移動量
            Vector3 enemyMove = new Vector3(Random.Range(-7.0f, 7.0f), 3.5f, 0.0f);

            // エネミーの移動
            mRb.AddForce(enemyMove, ForceMode.Impulse);

            // タイマー初期化
            moveTimer = 0.0f;

        }


        // タイマーの更新
        moveTimer += Time.deltaTime;
    }
}
