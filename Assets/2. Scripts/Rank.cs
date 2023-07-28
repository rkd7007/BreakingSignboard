using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{

    public Text Ranking;
    public GameObject RankingMenu;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Ranking.text += (i + 1).ToString() + " " + PlayerPrefs.GetString("name" + i.ToString()) + "  " + PlayerPrefs.GetInt(i.ToString()) + "\n\n";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll(); //초기화
        }
    }
}