//****************************************
// Sound.cs
// 任意のタイミングでSEを鳴らすプログラム
//****************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    //[SerializeField]
    //AudioClip soundEffect;           // SEの音源

    AudioSource audioSource;    // SEを鳴らす用

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // スペース
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //SEを鳴らす
        //    audioSource.PlayOneShot(sound1);
        //}
    }

    void OnCollisionEnter(Collision col)
    {
         Destroy(col.gameObject);
         audioSource.PlayOneShot(audioSource.clip);
        
    }
}
