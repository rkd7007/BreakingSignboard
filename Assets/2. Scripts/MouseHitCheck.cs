using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //PointerEventData 사용하기위해 


public class MouseHitCheck : MonoBehaviour , IPointerEnterHandler
{
    public AudioSource BottonSound;
    private float BottonVol= 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.BottonSound.volume = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData) //마우스포인터가 충돌범위안에 들어올때 이벤트
    {
        //Debug.Log("dddd");
        BottonSound.Play();


    }
}
