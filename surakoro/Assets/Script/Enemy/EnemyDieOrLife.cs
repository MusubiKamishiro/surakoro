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
            if (this.transform.position.y > 100 || this.transform.position.y < -100)
            {
                Destroy(effect);
                stomachInFlag = true;
                this.tag = this.tag + "Score";
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                this.transform.localScale = this.transform.localScale * 0.2f;
                this.transform.position = stomachFloor.transform.position + new Vector3(0.0f, 15.0f, 0.0f);
            }
        }
    }
}
