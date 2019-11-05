//***************************************
// EnemyDieOrLife.cs
// Enemyが生きてるか死んでるかのクラス
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieOrLife : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        // 下に落ちすぎたら
        if (this.transform.position.y < -10)
        {
            // これを消す
            Destroy(this.gameObject);
        }
    }
}
