//---------------------------------------------------------------------//
// ゴール地点の当たり判定(Playerが接触したらリザルトへ) Debug
//                                       Yutaro Ono.
//--------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPointTrigger : MonoBehaviour
{

    // プレイヤーが触れたらリザルトへ
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Player")
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
