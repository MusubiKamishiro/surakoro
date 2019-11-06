using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Sound sound;
    private float speed = 1.5f;     // デバッグ用のプレイヤー移動速度
    private Vector3 growingSize = new Vector3(20, 20, 0);	// 敵を食べて大きくなるサイズ
	private List<bool> giantFlag = new List<bool>();
	private List<int> wallBreakCounts = new List<int>();
	private int count = 0;
   

	public int firstWallBreakCount = 5;
	public int second = 8;
	private bool gFlag = true;

	public Vector3 GetGrowingSize()
	{
		return growingSize;
	}

	// Start is called before the first frame update
	void Start()
    {
        
		for (int i = 0; i < 5; ++i)
		{
			giantFlag.Add(true);
			wallBreakCounts.Add((i + 1) * 5);
		}
	}

    // Update is called once per frame
    void Update()
    {
        // デバッグ用の移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

		PlayerCollider pc = FindObjectOfType<PlayerCollider>();
		for(int i = 0; i < 5; ++i)
		{
			if (pc.GetTotalEatNum() > wallBreakCounts[i])
			{

                if (giantFlag[i])
				{

                    Giant(i);
				}
			}
		}
    }

    void Giant(int ccount)
    {
        sound.PlayWithoutOverlap(0);
        transform.localScale += growingSize / 60;
        if (count > 60)
        {

            giantFlag[ccount] = false;
            count = 0;
		}
        ++count;
    }
}
