using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignMove : MonoBehaviour
{

    public GameObject signIMA; //간판
    public static bool isFail; //간판 화면밖으로 넘어갓나?
    public static bool isComplete; //성공여부

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (UIManager.CheckTimeOut == false)
        {

            //간판의 x위치를 +0.08씩 이동
            signIMA.transform.Translate(3.75f, 0, 0);
        }

        

        //다 입력하지 못한 트레일러가 화면에서 안보이면 되돌아옴
        if (signIMA.transform.position.x > 1200.2783f)
        {
            //이미지가 바뀌고 화살표도 초기화되어야한다.
            signIMA.transform.position = new Vector3(43.3f,140f, 0);
            isFail = true;
        }

        else if(isComplete == true) //키입력실패 또는 모든키입력 성공 -> 좌쉬프트 입력시
        {
            signIMA.transform.position = new Vector3(43.3f, 140f, 0);

            isComplete = false;
        }

    }
}
