//***************************************
// Ibukuro.cs
// Ibukuroにつけるプログラム
//***************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ibukuro : MonoBehaviour
{
    private static int[] enemyScore = new int[4];     // Ibukuroの中にあるエネミーScoreの数
    public static int EnemyScoreGet(int i)
    {
        return enemyScore[i];
    }

    // ここでしか使わない変数
    private CapSensor capSensor;    // フラグ呼び出し用
    void Start()
    {
        // capSensorのインスタンスを見つける
        capSensor = FindObjectOfType<CapSensor>();
    }

    int Check(string tagname)
    {
        GameObject[] tagObjects;
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
        return tagObjects.Length;
    }

    void Update()
    {
        enemyScore[0] = Check("RedScore");
        enemyScore[1] = Check("BlueScore");
        enemyScore[2] = Check("GreenScore");
        enemyScore[3] = Check("YellowScore");
        //ボーナスに入ったら
        //if (capSensor.BonusFlag)
        {
            //ボーナス要素を追加したい（Scoreを増やす等）
        }
    }
}
