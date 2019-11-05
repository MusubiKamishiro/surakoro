using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    private bool mPausedFlag = false;
    [SerializeField]
    private GameObject mPauseMenuUI = null;
    [SerializeField]
    private GameObject mGameUI = null;


    [HideInInspector]
    public static SceneMng mInstance = null;
    public static SceneMng Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject obj = new GameObject();
                obj.name = nameof(SceneMng);
                mInstance = obj.AddComponent<SceneMng>();
                DontDestroyOnLoad(obj);

            }
            return mInstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mPauseMenuUI != null)
        {
            mPauseMenuUI.SetActive(false);
        }
    }

    void Awake()
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (Input.GetKeyDown("escape") && !mPausedFlag)
            {
                Pause();
            }
        }
    }

    public void MoveScene()
    {
        Debug.Log("シーン遷移");
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int maxSceneNum = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((activeSceneIndex + 1) % maxSceneNum);
        
    }

    public void Pause()
    {
        Debug.Log("Pause");
        mGameUI.SetActive(false);
        mPauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        mPausedFlag = true;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        mGameUI.SetActive(true);
        mPauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        mPausedFlag = false;
    }
}
