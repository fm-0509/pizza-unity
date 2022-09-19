using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volume : MonoBehaviour
{
    [SerializeField] private Slider slider;
    void Start()
    {
        ScriptMusica.instance.ChangeVolume(slider.value);
        slider.onValueChanged.AddListener(val=> ScriptMusica.instance.ChangeVolume(val));
    }

}
