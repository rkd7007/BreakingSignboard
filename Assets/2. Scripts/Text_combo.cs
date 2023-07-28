using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_combo : MonoBehaviour
{
    public Text combo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(UIManager.CheckScoreCombo !=0)
        //{

        if(UIManager.CheckTimeOut == false)
        {
            combo.text = UIManager.CheckScoreCombo + " Combo !!"; //텍스트 표시 (Mathf.Round로 소수점을 젠)
        }

        //}
    }
}
