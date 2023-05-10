using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public TextMeshProUGUI timerTexto;
    public int valor;
    private float time;
    public int segundos;
    public int ms;
    // Start is called before the first frame update
    void Start()
    {
        timerTexto = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        segundos = Mathf.FloorToInt(time % 60F);
        PlayerPrefs.SetInt("seg", segundos);
        timerTexto.text = String.Format("{0}s", segundos.ToString("00"));
    }
}
