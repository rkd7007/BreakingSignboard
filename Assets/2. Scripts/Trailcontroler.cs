using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for unity function use.
using UnityEngine.SceneManagement;

public class Trailcontroler : MonoBehaviour
{

    public GameObject Trail, Trail2; // 트레일러


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //시간이 갈때만
        if (UIManager.CheckTimeOut == false)
        {
            //트레일러1의 x위치를 +0.01씩 이동 
            Trail.transform.Translate(0.055f, 0, 0);

            //트레일러2의 x위치를 +0.01씩 이동 
            Trail2.transform.Translate(0.055f, 0, 0);



            //트레일러가 화면에서 안보이면 되돌아옴
            if (Trail.transform.position.x > 14)
            {
                //Destroy(Trail);

                Trail.transform.position = new Vector3(-14.36f, 9.18f, 0);
            }

            //트레일러가 화면에서 안보이면 되돌아옴
            if (Trail2.transform.position.x > 14)
            {
                //Destroy(Trail);

                Trail2.transform.position = new Vector3(-14.36f, 9.18f, 0);
            }


        }
    }
}
