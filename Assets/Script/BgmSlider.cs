using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class BgmSlider : MonoBehaviour
{
    public AudioSource AudioSource;
    public Slider Slider;

    const float DEFAULT_VALUE = 0.5f; 

    void Start()
    {
        Slider = this.GetComponent<Slider>();
        //volumeの初期値
        AudioSource.volume = DEFAULT_VALUE;
        //Sliderの初期値
        Slider.value = DEFAULT_VALUE;
        
    }

    void Update()
    {
        //sliderの値が変更された際に呼び出される 
        Slider.onValueChanged.AddListener(OnSlide);

    }

    public void OnSlide(float value)
    {
        //sliderのvalueをAudioSourceのvolumeへセット
        AudioSource.volume = value;
    }

}
