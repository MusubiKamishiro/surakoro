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
    GameObject effectPrefab;    // 敵が死んだとき、胃袋に飛ばすときのエフェクト

    [SerializeField]
    GameObject stomachFloor;     // 胃の床

    [SerializeField]
    float Scale;                // キャラのサイズ

    bool dieFlag;
    bool stomachInFlag;
    float dieTime;
    GameObject effect;

    void Start()
    {
        dieFlag = false;
        stomachInFlag = false;
        dieTime = 0.0f;
    }

    void OnCollisionStay(Collision other)
    {
        // プレイヤーに当たった瞬間
        if (other.gameObject.tag == "Player" && !dieFlag)
        {
            // エネミーにエフェクトをつける
            effect = Instantiate(effectPrefab) as GameObject;
            // 飛んでくフラグを立てる
            dieFlag = true;
        }
    }

    void Update()
    {

        if (dieFlag && !stomachInFlag)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            effect.transform.position = this.transform.position;
            this.transform.position += new Vector3(0.0f, 1.0f, 1.0f).normalized;
            dieTime += Time.deltaTime;
            if (dieTime > 5.0f)
            {
                Destroy(effect);
                stomachInFlag = true;
                this.tag = this.tag + "Score";
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.transform.localScale = this.transform.localScale * Scale;
                this.transform.position = stomachFloor.transform.position + new Vector3(0.0f, 15.0f, 0.0f);
            }
        }
    }
}
