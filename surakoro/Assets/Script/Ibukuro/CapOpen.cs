//***************************************
// CapOpen.cs
// capにつけるプログラム
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapOpen : MonoBehaviour
{
    // 外部から読み込み
    [SerializeField]
    GameObject leftCap;
    [SerializeField]
    GameObject rightCap;

    // ここでしか使わない変数
    private CapSensor capSensor;    // フラグ呼び出し用
    void Start()
    {
        // capSensorのインスタンスを見つける
        capSensor = FindObjectOfType<CapSensor>();
    }

    void Update()
    {
        // 蓋が開くフラグがたったら
        if (capSensor.OpenFlag)
        {
            
        }
    }
}