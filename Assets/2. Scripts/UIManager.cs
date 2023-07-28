using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //순서 = 0 : UP, 1: DOWN, 2:LEFT, 3:RIGHT, 4: SPACE
    public List<Sprite> RandomArrow;//랜덤으로 화면에 표시될 이미지 (회색 화살표)
    public List<Sprite> ChangeArrow;//정확하게 입력했을 때 표시될 이미지 (빨간 화살표)
    public List<Image> screenArrow;//화면상 이미지 UI 위치 (오브젝트)
    [SerializeField]
    private int curIndex = 0;//현재 내가 몇 번째 키보드를 입력하려는지 체크하는 변수

    //순서 = 0: 베라, 1: 샤넬, 2: 맥도날드, 3: 동서대, 4: 미용실, 5: 버거킹, 6: 나이키
    public List<Sprite> RandomSign; // 게임시작 시 랜덤으로 화면에 생성될 이미지 (간판)

    public List<Sprite> ChangeSign;//정확하게 입력했을 때 표시될 이미지 (베라간판)
    public List<Sprite> SignChanel;//정확하게 입력했을 때 표시될 이미지 (샤넬간판)
    public List<Sprite> SignDongseo;//정확하게 입력했을 때 표시될 이미지 (동서간판)
    public List<Sprite> SignHair;//정확하게 입력했을 때 표시될 이미지 (미용실간판)
    public List<Sprite> SignKing;//정확하게 입력했을 때 표시될 이미지 (버거킹간판)
    public List<Sprite> SignMac;//정확하게 입력했을 때 표시될 이미지 (맥간판)
    public List<Sprite> SignNike;//정확하게 입력했을 때 표시될 이미지 (나이키간판)

    public List<Image> ScreenSign;//화면상 이미지 UI 위치 (첫번째 간판오브젝트)

    public List<Image> ScreenotherSign;//화면상 이미지 UI 위치 (나머지 간판오브젝트)
    [SerializeField]



    public static bool CheckTimeOut = false; //타임아웃판넬 활성화 시 키입력 제어. (키입력무시하게)
                                             //=> TimeCheck 스크립트. 타임아웃 if 문 참조

    public static int CheckScoreCombo; //스코어 콤보를 체크함
    int SignRandomNum; // 간판생성하는 난수 (전역변수로 선언 -> 어떤간판나왓는지를 다른 함수에서 체크 필요)

    float CheckComboTime; //3초 안에 성공했는지 판단하는 변수
    bool Combo = false;

    public AudioSource SuccedAudio; //성공사운드
    public AudioSource WorngAudio; //실패사운드

    public AudioSource KeyAudio; //키입력사운드

    public AudioSource ComboAudio; //콤보사운드

    bool isMadeSign = false;

    void Start()
    {
        RandomImage();//게임 시작 시, 랜덤으로 이미지 출력
        RandomSignImage(); //게임 시작 시, 랜덤으로 간판이미지 출력 
        Combo = false;
    }

    void Update()
    {
        if (CheckTimeOut == false)
        {
            //트레일러가 다 지나갈동안 카보드 입력 실패
            if (SignMove.isFail == true)
            {
                CheckScoreCombo = 0;
                WorngAudio.Play(); // 실패소리재생
                RandomImage();
                RandomSignImage();
                TimeCheck.LimitTime -= 5; //실패 -> 시간 -1
                curIndex = 0;
                SignMove.isFail = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))//UP을 눌렀으면 
            {
                if (screenArrow[curIndex].sprite == RandomArrow[0])//화면상 이미지 UI 위치에 떠 있는 sprite랑 랜덤으로 화면에 표시될 이미지 0번째(UpArrow)와 같으면 (= 같은 키를 눌렀으면)
                {
                    screenArrow[curIndex].sprite = ChangeArrow[0];//화면상 이미지 UI 위치에 있는 sprite이미지를 정확하게 입력했을 때 표시될 이미지로 변환 (= 빨간 화살표로 변환)                             

                    KeyAudio.Play(); //키입력사운드재생

                    curIndex++;//다음 키보드와 체크하기 위해 index값 증가
                }
                else if (screenArrow[curIndex].sprite != RandomArrow[0])//화면에 표시될 이미지 0번째와 다르면 (= 다른 키를 눌렀으면)
                {
                    CheckScoreCombo = 0;
                    WorngAudio.Play();
                    SignMove.isComplete = true; //완료
                    RandomImage();//랜덤으로 이미지 다시 출력
                    RandomSignImage(); //랜덤으로 간판이미지 다시 출력                   
                    TimeCheck.LimitTime -= 5; //실패 -> 시간 -1
                    curIndex = 0;//0번째로 다시 바꿈

                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (screenArrow[curIndex].sprite == RandomArrow[1])
                {
                    screenArrow[curIndex].sprite = ChangeArrow[1];

                    KeyAudio.Play();

                    curIndex++;
                }
                else if (screenArrow[curIndex].sprite != RandomArrow[1])
                {
                    CheckScoreCombo = 0;
                    SignMove.isComplete = true; //완료
                    WorngAudio.Play();
                    RandomImage();
                    RandomSignImage();
                    TimeCheck.LimitTime -= 5; //실패 -> 시간 -1
                    curIndex = 0;

                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (screenArrow[curIndex].sprite == RandomArrow[2])
                {
                    screenArrow[curIndex].sprite = ChangeArrow[2];

                    KeyAudio.Play();

                    curIndex++;
                }
                else if (screenArrow[curIndex].sprite != RandomArrow[2])
                {
                    CheckScoreCombo = 0;
                    SignMove.isComplete = true; //완료
                    WorngAudio.Play();
                    RandomImage();
                    RandomSignImage();
                    TimeCheck.LimitTime -= 1; //실패 -> 시간 -1
                    curIndex = 0;

                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (screenArrow[curIndex].sprite == RandomArrow[3])
                {
                    screenArrow[curIndex].sprite = ChangeArrow[3];

                    KeyAudio.Play();

                    curIndex++;
                }
                else if (screenArrow[curIndex].sprite != RandomArrow[3])
                {
                    CheckScoreCombo = 0;
                    SignMove.isComplete = true; //완료
                    WorngAudio.Play();
                    RandomImage();
                    RandomSignImage();
                    TimeCheck.LimitTime -= 5; //실패 -> 시간 -1
                    curIndex = 0;

                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (screenArrow[curIndex].sprite == RandomArrow[4])
                {
                    screenArrow[curIndex].sprite = ChangeArrow[4];

                    KeyAudio.Play();

                    curIndex++;
                }
                else if (screenArrow[curIndex].sprite != RandomArrow[4])
                {
                    CheckScoreCombo = 0;
                    SignMove.isComplete = true; //완료
                    WorngAudio.Play();
                    RandomImage();
                    RandomSignImage();
                    TimeCheck.LimitTime -= 5; //실패 -> 시간 -1
                    curIndex = 0;

                }
            }

            if (curIndex > screenArrow.Count - 1)//현재 index값이 화면상에 표시된 이미지 위치 UI의 개수보다 크게 되면
            {
                //마지막 이미지 변환하는 장면이 안 뜸 - 수정하거나 아래 주석문 사용
                //RandomImage();//랜덤으로 이미지 다시 출력
                //curIndex = 0;//0번째로 다시 바꿈

                //마지막 이미지(키보드)를 맞추고 왼쪽 Shift눌렀을 때만 다음 랜덤 이미지 뜸(= 다음으로 넘어감)
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Combo = true;
                    SignMove.isComplete = true; //원래 위치로 돌아감
                    //성공사운드
                    SuccedAudio.Play();

                    if (CheckScoreCombo == 0) //1콤보
                    {
                        ScoreManager.AddScore += 10;
                        
                        CheckScoreCombo += 1;
                        CheckComboTime = 0;
                    }
                    else if (CheckScoreCombo == 1) //2콤보
                    {
                        if (CheckComboTime <= 5) //5초 안에 눌렀으면 
                        {
                            ScoreManager.AddScore += 11;
                            CheckScoreCombo += 1;
                            CheckComboTime = 0; //콤보 시간 0으로 초기화
                        }
                        else //5초 안에 못 눌렀으면
                        {
                            ScoreManager.AddScore += 10;
                            CheckComboTime = 0;
                        }
                    }
                    else if (CheckScoreCombo == 2) //3콤보
                    {
                        if (CheckComboTime <= 5)
                        {
                            ScoreManager.AddScore += 13;
                            CheckScoreCombo += 1;
                            CheckComboTime = 0;
                        }
                        else
                        {
                            ScoreManager.AddScore += 10;
                            CheckComboTime = 0;
                        }
                    }
                    else if (CheckScoreCombo == 3) //4콤보
                    {
                        if (CheckComboTime <= 5)
                        {
                            ScoreManager.AddScore += 16;
                            CheckScoreCombo += 1;
                            CheckComboTime = 0;
                        }
                        else
                        {
                            ScoreManager.AddScore += 10;
                            CheckComboTime = 0;
                        }
                    }
                    else if (CheckScoreCombo >= 4) //5콤보
                    {
                        if (CheckComboTime <= 5)
                        {
                            ScoreManager.AddScore += 20;

                            TimeCheck.LimitTime += 4; // 성공 5콤보 달성시 시간 5초 증가 (성공시간 1초에 +4)

                            CheckScoreCombo += 1;
                            CheckComboTime = 0;
                        }
                        else
                        {
                            ScoreManager.AddScore += 10;
                            CheckComboTime = 0;
                        }
                    }

                    //5 콤보 시 콤보사운드 출력
                    if(CheckScoreCombo % 5 == 0)
                    {
                        ComboAudio.Play();
                    }

                    RandomImage();
                    RandomSignImage();

                    TimeCheck.LimitTime += 1; //성공 -> 시간 +1

                    curIndex = 0;
                   

                }
            }
        }

        if (Combo == true)
        {
            CheckComboTime += Time.deltaTime; //시간 재기 시작
            //Debug.Log(CheckComboTime);
        }


        SignChange();


    }

    public void RandomImage()
    {
        foreach (Image rand in screenArrow)//foreach는 for와 비슷한 반복문
        {
            int index = Random.Range(0, 5);//0~4까지 랜덤으로 숫자 생성

            rand.sprite = RandomArrow[index];//0~4번 이미지 중에 랜덤으로 화면상에 표시될 UI 이미지를 바꿔줌
        }
    }


    public void RandomSignImage()
    {
        foreach (Image rand in ScreenSign)//foreach는 for와 비슷한 반복문
        {
            SignRandomNum = Random.Range(0, 6); //랜덤값을 0 ~ 6까지 만듦 

            rand.sprite = RandomSign[SignRandomNum];//0~6번 이미지 중에 랜덤으로 화면상에 표시될 UI 이미지를 바꿔줌
        }
    }

    public void SignChange()
    {
        if(curIndex == 1) //첫번째 키가 바르게 입력이 되었으면
        {
            if(SignRandomNum == 0)  //베라 간판일때
            {
                ScreenSign[0].sprite = ChangeSign[0]; //베라 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 1)  //샤넬 간판일때
            {
                ScreenSign[0].sprite = SignChanel[0]; //샤넬 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 2)  //맥도날드 간판일때
            {
                ScreenSign[0].sprite = SignMac[0]; //맥도날드 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 3)  //동서대학교 간판일때
            {
                ScreenSign[0].sprite = SignDongseo[0]; //동서대학교 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 4)  //미용실 간판일때
            {
                ScreenSign[0].sprite = SignHair[0]; //미용실 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 5)  //버거킹 간판일때
            {
                ScreenSign[0].sprite = SignKing[0]; //버거킹 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 6)  //나이키 간판일때
            {
                ScreenSign[0].sprite = SignNike[0]; //나이키 두번째 간판으로 바꾸어준다.
            }
        }

        if (curIndex == 2) // 두번째 키가 바르게 입력이 되었으면
        {
            if (SignRandomNum == 0)  //베라 간판일때
            {
                ScreenSign[0].sprite = ChangeSign[1]; //베라 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 1)  //샤넬 간판일때
            {
                ScreenSign[0].sprite = SignChanel[1]; //샤넬 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 2)  //맥도날드 간판일때
            {
                ScreenSign[0].sprite = SignMac[1]; //맥도날드 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 3)  //동서대학교 간판일때
            {
                ScreenSign[0].sprite = SignDongseo[1]; //동서대학교 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 4)  //미용실 간판일때
            {
                ScreenSign[0].sprite = SignHair[1]; //미용실 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 5)  //버거킹 간판일때
            {
                ScreenSign[0].sprite = SignKing[1]; //버거킹 두번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 6)  //나이키 간판일때
            {
                ScreenSign[0].sprite = SignNike[1]; //나이키 두번째 간판으로 바꾸어준다.
            }
        }

        if (curIndex == 3) // 세번째 키가 바르게 입력이 되었으면
        {
            if (SignRandomNum == 0)  //베라 간판일때
            {
                ScreenSign[0].sprite = ChangeSign[2]; //베라 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 1)  //샤넬 간판일때
            {
                ScreenSign[0].sprite = SignChanel[2]; //샤넬 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 2)  //맥도날드 간판일때
            {
                ScreenSign[0].sprite = SignMac[2]; //맥도날드 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 3)  //동서대학교 간판일때
            {
                ScreenSign[0].sprite = SignDongseo[2]; //동서대학교 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 4)  //미용실 간판일때
            {
                ScreenSign[0].sprite = SignHair[2]; //미용실 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 5)  //버거킹 간판일때
            {
                ScreenSign[0].sprite = SignKing[2]; //버거킹 세번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 6)  //나이키 간판일때
            {
                ScreenSign[0].sprite = SignNike[2]; //나이키 세번째 간판으로 바꾸어준다.
            }
        }

        if (curIndex == 4) // 네번째 키가 바르게 입력이 되었으면
        {
            if (SignRandomNum == 0)  //베라 간판일때
            {
                ScreenSign[0].sprite = ChangeSign[3]; //베라 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 1)  //샤넬 간판일때
            {
                ScreenSign[0].sprite = SignChanel[3]; //샤넬 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 2)  //맥도날드 간판일때
            {
                ScreenSign[0].sprite = SignMac[3]; //맥도날드 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 3)  //동서대학교 간판일때
            {
                ScreenSign[0].sprite = SignDongseo[3]; //동서대학교 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 4)  //미용실 간판일때
            {
                ScreenSign[0].sprite = SignHair[3]; //미용실 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 5)  //버거킹 간판일때
            {
                ScreenSign[0].sprite = SignKing[3]; //버거킹 네번째 간판으로 바꾸어준다.
            }

            if (SignRandomNum == 6)  //나이키 간판일때
            {
                ScreenSign[0].sprite = SignNike[3]; //나이키 네번째 간판으로 바꾸어준다.
            }
        }
    }


}




