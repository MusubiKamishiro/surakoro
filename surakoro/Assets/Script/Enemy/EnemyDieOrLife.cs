//***************************************
// EnemyDieOrLife.cs
// Enemyが生きてるか死んでるかのクラス
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieOrLife : MonoBehaviour
{
    [SerializeField]
    GameObject effectPrefab;   // 敵が死んだとき、胃袋に飛ばすときのエフェクト

    [SerializeField]
    GameObject effectGoul;   // 上のエフェクトのゴール

    Vector3 bitween;
    bool dieFlag;
    bool stomachInFlag;
    GameObject effect;

    void Start()
    {
        bitween = Vector3.zero;
        dieFlag = false;
        stomachInFlag = false;
    }

    void Update()
    {
        // 下に落ちすぎたら
        if (this.transform.position.y < -15 && !dieFlag)
        {
            // これにエフェクトをつける
            effect = Instantiate(effectPrefab) as GameObject;
            dieFlag = true;
        }
        if(dieFlag && !stomachInFlag)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            effect.transform.position = this.transform.position;
            this.transform.position += Vector3.up/2;
            if((effectGoul.transform.position - this.transform.position).magnitude < 1)
            {
                stomachInFlag = true;
                this.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
