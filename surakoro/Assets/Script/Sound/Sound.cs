//****************************************
// Sound.cs
// 任意のタイミングでSEを鳴らすプログラム
//****************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField]
    AudioClip sound1;           // SEの音源

    AudioSource audioSource;    // SEを鳴らす用

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // スペース
        if (Input.GetKey(KeyCode.Space))
        {
            //SEを鳴らす
            audioSource.PlayOneShot(sound1);
        }
    }
}
