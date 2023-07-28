using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PANEL_CONTROLER : MonoBehaviour
{

    public GameObject GameRulePanel;
    public static bool isRuleActive;

    void Awake()
    {
        UIManager.CheckTimeOut = true; //게임방법창이 떠있을때는 키입력x, 시간흐름x
        isRuleActive = true; //방법창이 켜져잇음
    }

    public void _ConTinueBotton()
    {
        Invoke("Cstartgame", .4f);
    }

    void Cstartgame()
    {
        GameRulePanel.SetActive(false); //게임방법창이 꺼짐
        isRuleActive = false; //방법창이 꺼짐확인
        UIManager.CheckTimeOut = false; //시간이흐르고, 키입력받을수잇게됨
        Cursor.visible = false; //마우스 커서 지움

    }

}
