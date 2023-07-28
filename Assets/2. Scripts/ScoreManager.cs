using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //static ScoreManager _instance = null; //싱글톤 패턴이라는 하나의 레퍼런스만 쓰겠다

    public static int AddScore; //변동점수로 사용할 변수
    public Text text_Score; //시각적으로 표시하기 위한 텍스트 UI


    // Update is called once per frame
    void Update ()
    {
        text_Score.text = "score : " + Mathf.Round(AddScore); //텍스트 표시 (Mathf.Round로 소수점을 젠)
    }
}
