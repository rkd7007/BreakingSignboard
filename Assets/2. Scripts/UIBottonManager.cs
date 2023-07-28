using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBottonManager : MonoBehaviour {

    void Awake()
    {

    }

    public void _StartBotton()
    {
        ScoreManager.AddScore = 0;
        Invoke("startgame", .4f);
    }


    public void _RankBotton()
    {
        Invoke("rank", .4f);
    }

    public void HomeBotton()
    {
        Invoke("Home", .4f);
    }

    public void Exit()
    {




#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#elif UNITY_WEBPLAYER

               Application.OpenURL("http://google.com");

#else

                 Application.Quit();

#endif

    }

    void rank()
    {
        //스타트 버튼 누르면 다음 씬으로 넘어감
        SceneManager.LoadScene("rank");
    }

    void startgame()
    {
        //스타트 버튼 누르면 다음 씬으로 넘어감
        SceneManager.LoadScene("Stage1");

    }

    void Home()
    {
        //스타트 버튼 누르면 다음 씬으로 넘어감
        SceneManager.LoadScene("Mainmenu");
    }
}
