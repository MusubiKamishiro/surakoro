//***************************************
// Ibukuro.cs
// Ibukuroにつけるプログラム
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ibukuro : MonoBehaviour
{
    // ここでしか使わない変数
    private CapSensor capSensor;    // フラグ呼び出し用
    void Start()
    {
        // capSensorのインスタンスを見つける
        capSensor = FindObjectOfType<CapSensor>();
    }

    void Update()
    {
        // ボーナスに入ったら
        if(capSensor.BonusFlag)
        {
            //ボーナス要素を追加したい（Scoreを増やす等）
        }
    }
}
