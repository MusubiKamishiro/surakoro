//****************************************
// Sound.cs
// 任意のタイミングでSEを鳴らすプログラム
//****************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sound : MonoBehaviour
{

    [SerializeField]
    AudioClip[] extraEffect;           // SEの音源
    DateTime startPlayingTime; //SE開始時間
    bool playingFlag = false;  //SE流しているか

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
        //エネミーレイヤー
        if (col.gameObject.layer == 9)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    public void PlayWithoutOverlap(int idx)
    {
        if (!playingFlag)
        {
            startPlayingTime = DateTime.UtcNow;
            audioSource.PlayOneShot(extraEffect[idx]);
            playingFlag = true;
        }
        else
        {            
            if ((DateTime.UtcNow - startPlayingTime).Seconds > extraEffect[idx].length/2)
            {
                playingFlag = false;
            }
        }
    }

    public void PlayWithOverlap(int idx)
    {
        audioSource.PlayOneShot(extraEffect[idx]);
    }

    public AudioClip GetSE(int idx)
    {
        return extraEffect[idx];
    }
}
