using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aボタンが入力されたら
        if(Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene("in-Game");
        }
    }
}
