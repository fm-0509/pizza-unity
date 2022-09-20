using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        if(PlayerPrefs.HasKey("volume"))
            slider.value = PlayerPrefs.GetFloat("volume");
        ScriptMusica.instance.ChangeVolume(slider.value);
        slider.onValueChanged.AddListener(val => ScriptMusica.instance.ChangeVolume(val));
    }

   

}
