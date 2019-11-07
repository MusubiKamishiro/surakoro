using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mPostVolume;
    private int profileNow = 0;
    [SerializeField]
    private Light mLight;
    DateTime mTimeOld;
    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        int rand = UnityEngine.Random.Range(0, mPostVolume.Length);
        ChangeWeather(0);
        mTimeOld = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mPostVolume.Length; i++)
        {
            if (!player.GetGiantFlag(i))
            {
                ChangeWeather((i + 1) % mPostVolume.Length);
            }
        }
        //var timeNow = DateTime.Now;
        //if (timeNow - mTimeOld >= TimeSpan.FromSeconds(10))
        //{
        //    mTimeOld = DateTime.Now;
        //    ChangeWeather((profileNow + 1) % mPostVolume.Length);
        //}
    }

    //ポストプロセスのプロファイルを変える
    public void ChangeWeather(int idx)
    {
        //if (mPostVolume[idx].activeSelf) return;
        if (profileNow <= idx)
        {
            for (int i = 0; i < (int)mPostVolume.Length; i++)
            {
                mPostVolume[i].SetActive(false);
            }
            mPostVolume[idx].SetActive(true);
            mLight.shadows = mPostVolume[idx].name == "Night" ? LightShadows.None : LightShadows.Soft;
            profileNow = idx;
        }
    }
    
}
