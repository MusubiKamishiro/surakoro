using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
	// Start is called before the first frame update
	Score s = new Score();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("最終得点：" + s.GetScore());
		if (Input.GetKey(KeyCode.O))
		{
			SceneManager.LoadScene("player");
		}
	}
}
