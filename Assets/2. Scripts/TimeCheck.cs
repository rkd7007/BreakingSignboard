using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //텍스트 UI 사용함
using UnityEngine.SceneManagement;

public class TimeCheck : MonoBehaviour
{

    //public int Time;
    //public int CurrentTime;
    //public Slider TimeSlider;
    //bool isPanel;
    //public GameObject panel;


    public float FirstTime; //전체시간으로 사용할 변수
    public static float LimitTime; //변동시간으로 사용할 변수

    //public Text text_Timer; //시각적으로 표시하기 위한 텍스트 UI
    public Slider TimeSlider; //타이머 슬라이더UI

    public GameObject Timeover_panel;//시간이 0이되면 타임오버창 띄우기위함

    bool GetName = false;

    public InputField newname; //닉네임 적는 필드
    public GameObject NameBox; //닉네임 적는 필드 가려줄 닉네임 박스

    public GameObject WarningPanel; //제한시간이 다 되어가면 활성화되어서 빨갛게 경고
    public static bool isWarning; //10초이하인지 체크
   

    private string Name = null;


    bool IsBreak;

    // Use this for initialization
    void Start()
    {
        IsBreak = false;
        LimitTime = 60;
        Timeover_panel.SetActive(false); //타임오버창 false
        GetName = false;
        WarningPanel.SetActive(false);
        NameBox.SetActive(false); //게임 시작하면 없앰(안보이게 함)

    }

    // Update is called once per frame
    void Update()
    {
        TimeSlider.maxValue = FirstTime;

        //성공 또는 5콤보로 시간상승 시 제한시간이 60을 넘어서 타이머가 멈춘것처럼 보이는 것 방지(= 제한시간은 1분을 넘어갈수없음)
        if(LimitTime > 60)
        {
            LimitTime = 60;
        }

        if(LimitTime < 10) //제한 시간이 10초 이하가되면
        {
           isWarning = true;
        }

        else if(LimitTime >=10) //아니라면
        {
            isWarning = false;
        }

        if (isWarning == true)
        {
            WarningPanel.SetActive(true); //경고창띄움
        }

        else if (isWarning == false)
        {
            WarningPanel.SetActive(false); //경고창지움
        }

        if (UIManager.CheckTimeOut == false) //키입력을 받을수있을때에만
        {
            LimitTime -= Time.deltaTime; // 일정한 시간에 따라 감소되도록 만듦
        }

        TimeSlider.value = LimitTime;

        //타임아웃
        if (LimitTime <= 0)
        {
            Cursor.visible = true; //마우스 다시 보임


            WarningPanel.SetActive(false); //경고창지움
            Timeover_panel.SetActive(true); //타임오버창 true
            UIManager.CheckTimeOut = true;
            //Time.timeScale = 0; //시간을 멈춘다 //슬라이더라서 필요가없네

            NameBox.SetActive(true); //닉네임 적는 박스 등장
            Name = newname.text; //닉네임 필드에 적은 TEXT(닉네임)가 NAME이 된다

            PlayerPrefs.SetString("name" + "10", newname.text); //이름과
            PlayerPrefs.SetInt("10", ScoreManager.AddScore); //내 점수를 11등에 저장해놓는다

            if (IsBreak == false) { /*InsertBank();*/ IsBreak = true; } //한 번 랭킹을 정리하고 멈춘다

            if (Name.Length > 0 && Input.GetKeyDown(KeyCode.Return))
            {
                InsertBank();
                SceneManager.LoadScene("Mainmenu");
            }
        }


        //text_Timer.text = "시간 : " + Mathf.Round(LimitTime); //텍스트 표시 (Mathf.Round로 소수점을 젠)
    }
    void InsertBank()
    {
        for (int i = 0; i < 10; i++)//0부터 9까지, 총 10번 돌림 (1등을 제외한 나머지와(2등~11등)만 비교하면 되기 때문)
        {
            int tempIndex = i; //처음 값이 들어있는 인덱스를 저장한다

            for (int j = i + 1; j < 11; j++) //i = 0이면, 0제외 1부터 시작(i+1)
            {
                //만약 처음 값이 들어있는 인덱스보다 바로 아래에 있는 값이 크면 (1등 값 < 2등 값)
                if (PlayerPrefs.GetInt(tempIndex.ToString()) < PlayerPrefs.GetInt(j.ToString()))
                {
                    tempIndex = j;//그 인덱스를 저장한다
                }
            }
            //가장 큰 값과 처음 값을 스왑하는 부분
            int tempValue = PlayerPrefs.GetInt(i.ToString()); //처음 값을 변수에 저장한다
            string tempChar = PlayerPrefs.GetString("name" + i.ToString()); //처음 닉네임을 변수에 저장한다

            PlayerPrefs.SetInt(i.ToString(), PlayerPrefs.GetInt(tempIndex.ToString())); //가장 큰 값을 가진 인덱스를 처음 값에 저장한다
            PlayerPrefs.SetString("name" + i.ToString(), PlayerPrefs.GetString("name" + tempIndex.ToString())); //가장 큰 값을 가진 인덱스의 닉네임을 처음 값에 저장한다

            PlayerPrefs.SetInt(tempIndex.ToString(), tempValue); //처음 값이 가장 큰 값이 있던 인덱스에 저장된다
            PlayerPrefs.SetString("name" + tempIndex.ToString(), tempChar); //처음 값의 닉네임이 가장 큰 값이 있던 인덱스에 저장된다
        }
    }
}
