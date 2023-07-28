using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManger : MonoBehaviour
{
    public Slider backVolume;
    public AudioSource audio_Main;
    public static float VolumeCheck; //다른사운드를 동시에 조정

    public AudioSource TimeOver;
    public AudioSource WarningAudio;


    private float backVol = 1f;

    public static bool isTimeOver; //시간이 끝났는지 체크
    public static bool isFlag;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);//처음켰을때 사운드값이 0이되어 소리가 안나는 것 방지
        backVolume.value = backVol;
        audio_Main.volume = backVolume.value;
        WarningAudio.volume = 0.3f;
        WarningAudio.pitch = 0.7f;


        isTimeOver = false;
        isFlag = false;

    }

    // Update is called once per frame
    void Update()
    {

        VolumeCheck = audio_Main.volume;
        SoundSlider();

        if (TimeCheck.isWarning == true && TimeCheck.LimitTime > 0)//10초 이하가 되면
        {
            if (!WarningAudio.isPlaying)
            {
                WarningAudio.Play();
            }
        }

        else if (TimeCheck.isWarning == false || TimeCheck.LimitTime <= 0)
        {
            WarningAudio.Stop();

        }


        if (TimeCheck.isWarning == true && UIManager.CheckTimeOut == false) //게임이 시작되었고, 제한시간이 10초 이하가 되면
        {
            audio_Main.pitch = 1.4f; //1.4의 속도로 재생
        }
        else //10초 이상일때에는 
            audio_Main.pitch = 1; //1의 속도로 재생


        if (TimeCheck.LimitTime <= 0 && isTimeOver == false) //시간이 끝
        {
            audio_Main.Stop(); //메인음악끄고
                               //Debug.Log("TimeOver Time : " + TimeOver.time);

            isTimeOver = true; //타임오버


        }

        if (isTimeOver == true && isFlag == false)
        {
            //=> if문이 없으면 소리가 계속 재생되어서 안나오는것 처럼 들림
            if (!TimeOver.isPlaying) //타임아웃 소리가 나오지않고 있을때
            {
                TimeOver.Play(); //타임아웃소리재생
                isFlag = true; //소리여러번안나오게 플래그 세움
                isTimeOver = false;

                //Debug.Log("게임오버ㅅ확인");
            }


        }
    }


    public void SoundSlider()
    {
        audio_Main.volume = backVolume.value;


        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
}