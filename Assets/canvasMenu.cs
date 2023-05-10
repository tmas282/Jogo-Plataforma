using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasMenu : MonoBehaviour
{
    public Button btnJogar;
    public Button btnToturiais;
    public Button btnSair;
    public Button btnOpcoes;
    
    
    void OnClickJogar()
    {
        SceneManager.LoadScene("nivel3");
    }
    void OnClickToturiais()
    {
        SceneManager.LoadScene("nivel1");
    }
    void OnClickSair()
    {
        Application.Quit();
    }
    void OnClickOpcoes()
    {
        SceneManager.LoadScene("opcoes");
    }
    void Start()
    {
        btnJogar.onClick.AddListener(OnClickJogar);
        btnToturiais.onClick.AddListener(OnClickToturiais);
        btnSair.onClick.AddListener(OnClickSair);
        btnOpcoes.onClick.AddListener(OnClickOpcoes);
        
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "menu")
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
        if (PlayerPrefs.HasKey("musicaVol") == false)
        {
            PlayerPrefs.SetFloat("musicaVol", 1f);
        }
        if (PlayerPrefs.HasKey("inverter") == false)
        {
            PlayerPrefs.SetString("inverter", "False");
        }
    }
}
