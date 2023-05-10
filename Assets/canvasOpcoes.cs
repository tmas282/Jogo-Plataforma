using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvasOpcoes : MonoBehaviour
{
    public Slider sliderMusica;
    public Toggle toggleFullscreen;
    public Toggle toggleInverter;
    public Button btnVoltar;
    void OnClickVoltar()
    {
        SceneManager.LoadScene("menu");
    }
    void OnValueChangedMusica(float vol)
    {
        PlayerPrefs.SetFloat("musicaVol", vol);
    }
    void Start()
    {
        btnVoltar.onClick.AddListener(OnClickVoltar);
        sliderMusica.onValueChanged.AddListener(OnValueChangedMusica);
        sliderMusica.value = PlayerPrefs.GetFloat("musicaVol");
        toggleInverter.isOn = false;
        if (PlayerPrefs.GetString("inverter") == "True")
        {
            toggleInverter.isOn = true;
        }
    }
    void Update()
    {
        Screen.fullScreen = toggleFullscreen.isOn;
        if (toggleInverter.isOn)
        {
            PlayerPrefs.SetString("inverter", "True");
        }
        else
        {
            PlayerPrefs.SetString("inverter", "False");
        }
    }
}
