using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    InputManager mInput;

    FadeScript mFade;
    [SerializeField]
    AudioSource audioSource;


    // 次シーン切り替えのフラグ
    public bool nextScene;

    // Start is called before the first frame update
    void Start()
    {
        // InputManager取得
        GameObject inputObj = GameObject.Find("InputManager");
        mInput = inputObj.GetComponent<InputManager>();

        // FadeScript取得
        GameObject fadeObj = GameObject.Find("FadeManager");
        mFade = fadeObj.GetComponent<FadeScript>();

        nextScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        // Aボタンが入力されたら
        if(mInput.GetEnter() == true)
        {
            nextScene = true;
            audioSource.PlayOneShot(audioSource.clip);
        }

        // 次シーンへの遷移フラグが立ったら
        if(nextScene == true)
        {

            if (mFade.FadeIn(1.0f))
            {
                SceneMng.Instance.MoveScene();
            }
        }
    }
}
