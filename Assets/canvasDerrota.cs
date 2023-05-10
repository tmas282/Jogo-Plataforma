using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasDerrota : MonoBehaviour
{
    public Button btnJogar;
    public Button btnMenu;
    void OnClickVoltarAJogar()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("nivelEmQueMorreu"));
    }
    void OnClickVoltarAoMenu()
    {
        SceneManager.LoadScene("menu");
    }
    void Start()
    {
        btnJogar.onClick.AddListener(OnClickVoltarAJogar);
        btnMenu.onClick.AddListener(OnClickVoltarAoMenu);
    }
}
