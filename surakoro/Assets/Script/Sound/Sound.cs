//****************************************
// Sound.cs
// 任意のタイミングでSEを鳴らすプログラム
//****************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    [SerializeField]
    AudioClip extraEffect;           // SEの音源

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

        if (col.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.Log("extraSound"); 
            //audioSource.PlayOneShot(extraEffect);

        }
    }
}
