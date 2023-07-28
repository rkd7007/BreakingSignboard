using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSoundManager : MonoBehaviour
{

    public Slider EffectVolume;
    public AudioSource EffectAudio;

    private float EffectVol = 0.4f;



    // Start is called before the first frame update
    void Start()
    {
        EffectVol = PlayerPrefs.GetFloat("EffectVol", 0.4f);//처음켰을때 사운드값이 0이되어 소리가 안나는 것 방지
        EffectVolume.value = EffectVol;
        EffectAudio.volume = EffectVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }


    public void SoundSlider()
    {
        EffectAudio.volume = EffectVolume.value;


        EffectVol = EffectVolume.value;
        PlayerPrefs.SetFloat("EffectVol", EffectVol);
    }
}
