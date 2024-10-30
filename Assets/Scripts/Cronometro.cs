using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CronometroTMP : MonoBehaviour
{
    public TextMeshProUGUI cronometroText;
    private float tiempo = 0f;
    private bool enMarcha = false;

    void Start()
    {
        enMarcha = true;
    }

    void Update()
    {
        if (enMarcha)
        {
            tiempo += Time.deltaTime;
            int minutos = Mathf.FloorToInt(tiempo / 60F);
            int segundos = Mathf.FloorToInt(tiempo % 60F);
            int milisegundos = Mathf.FloorToInt((tiempo * 100F) % 100F);
            cronometroText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
        }
    }

    public void IniciarCronometro()
    {
        enMarcha = true;
        tiempo = 0f; // Reiniciar tiempo
    }

    public void DetenerCronometro()
    {
        enMarcha = false;
    }

    public void ReiniciarCronometro()
    {
        enMarcha = true;
        tiempo = 0f;
    }
}
