using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class canvasVitoria : MonoBehaviour
{
    public Button btnVoltarAJogar;
    public Button btnVoltarAoMenu;
    public TextMeshProUGUI tempo;
    public TextMeshProUGUI highscore; 
    int segundos;
    void OnClickVoltarAJogar()
    {
        SceneManager.LoadScene("nivel3");
    }
    void OnClickVoltarAoMenu()
    {
        SceneManager.LoadScene("menu");
    }
    void Start()
    {
        segundos = PlayerPrefs.GetInt("seg");
        btnVoltarAJogar.onClick.AddListener(OnClickVoltarAJogar);
        btnVoltarAoMenu.onClick.AddListener(OnClickVoltarAoMenu);
        tempo = GameObject.Find("tempo").GetComponent<TextMeshProUGUI>();
        highscore = GameObject.Find("highscore").GetComponent<TextMeshProUGUI>();
        tempo.text = String.Format("Tempo: {0}s", segundos.ToString("00"));
        if(PlayerPrefs.HasKey("hs") == false || PlayerPrefs.GetInt("hs") == 0)
        {
            PlayerPrefs.SetInt("hs", segundos);
        }
        else
        {
            if(segundos < PlayerPrefs.GetInt("hs"))
            {
                PlayerPrefs.SetInt("hs", segundos);
            }
        }
        highscore.text = String.Format("HighScore: {0}s", PlayerPrefs.GetInt("hs").ToString("00"));
    }

}
