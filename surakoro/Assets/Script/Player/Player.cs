using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject wallBreakEffect;

    [SerializeField]
    List<float> gravity = new List<float>();
    [SerializeField]
    private Sound sound;
    private int t = 0;


    private float speed = 1.5f;     // デバッグ用のプレイヤー移動速度
    public Vector3 growingSize = new Vector3(20, 20, 0);    // 敵を食べて大きくなるサイズ
    private List<bool> giantFlag = new List<bool>();        // 巨大化の段階
    private List<int> wallBreakCounts = new List<int>();
	private float secondCount = 0;

    public Vector3 GetGrowingSize()
	{
		return growingSize;
	}
	public bool GetGiantFlag(int i)
	{
		return giantFlag[i];
	}

	// Start is called before the first frame update
	void Start()
    {
		PlayerCollider pc = FindObjectOfType<PlayerCollider>();
        for (int i = 0; i < pc.GetWallNum(); ++i)
		{
			giantFlag.Add(true);
            if(i == 0)
            {
                wallBreakCounts.Add((i + 1) * 5);
            }
            else
            {
                wallBreakCounts.Add((i + 1) * (10 * i));
            }

		}
	}

    private void FixedUpdate()
    {
        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
    }

    private void SetLocalGravity()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float grav = 0;
        if (!giantFlag[4])
        {
            grav = gravity[4];
        }
        else if (!giantFlag[3])
        {
            grav = gravity[3];
        }
        else if (!giantFlag[2])
        {
            grav = gravity[2];
        }
        else if (!giantFlag[1])
        {
            grav = gravity[1];
        }
        else if (!giantFlag[0])
        {
            grav = gravity[0];
        }
        rigidbody.AddForce(new Vector3(0.0f, grav, 0.0f), ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update()
    {
     	// 特定の大きさになったら壁を破壊する
		PlayerCollider pc = FindObjectOfType<PlayerCollider>();
		for(int i = 0; i < pc.GetWallNum(); ++i)
		{
			if (pc.GetTotalEatNum() > wallBreakCounts[i])
			{
				if (giantFlag[i])
				{
					Giant(i);
                    wallBreakEffect.transform.position = this.transform.position;
                }
			}
		}
    }

	// プレイヤーの巨大化
    void Giant(int count)
    {
        sound.PlayWithoutOverlap(0);
        if(t < 60)
        {
            transform.localScale += growingSize / 60;
            ++t;
        }
       
        if (secondCount > 1)
        {
            giantFlag[count] = false;
			growingSize *= 2;
			secondCount = 0;
            t = 0;
		}
		secondCount += Time.deltaTime;
    }
}
