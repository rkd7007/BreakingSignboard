using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    public GameObject _SettingPanel;

    bool isSetAwake = false;

    // Start is called before the first frame update
    void Start()
    {
        _SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PANEL_CONTROLER.isRuleActive == false) //게임방법창이 켜져있을때는 게임설정창 켤수 없음
        {
            if (isSetAwake == false && Input.GetKeyDown(KeyCode.Escape)) //게임설정창켜기
            {
                _SettingPanel.SetActive(true);
                isSetAwake = true;
                Cursor.visible =  true; //마우스 커서 켬
                UIManager.CheckTimeOut = true; //시간멈춤
            }


            else if (isSetAwake == true && Input.GetKeyDown(KeyCode.Escape))//게임설정창끄기
            {
                _SettingPanel.SetActive(false);
                isSetAwake = false;
                UIManager.CheckTimeOut = false;//시간흐름
                //Cursor.visible = false; //마우스 커서 지움

            }
        }

    }
}
