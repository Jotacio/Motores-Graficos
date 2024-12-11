using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int VidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    public UnityEvent vidaCero; // Evento que se dispara cuando la vida llega a 0
    public GameObject lostText;

    public int valorPrueba;
    private CronometroTMP cronometro;
    private Escudo escudo; // Referencia al escudo

    private void Start()
    {
        VidaActual = vidaMaxima;
        cambioVida.Invoke(VidaActual);
        cronometro = FindObjectOfType<CronometroTMP>();
        escudo = GetComponent<Escudo>();
        if (escudo == null)
        {
            Debug.LogWarning("El jugador no tiene un componente Escudo. Asegúrate de añadir el script Escudo al jugador.");
        }
        lostText.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TomarDaño(valorPrueba);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CurarVida(valorPrueba);
        }
    }

    public void TomarDaño(int cantidadDaño)
    {
        if (escudo != null && escudo.BloquearDaño())
        {
            Debug.Log("El daño ha sido bloqueado por el escudo.");
            return; // Bloquear el daño si el escudo está activo
        }

        int vidaTemporal = VidaActual - cantidadDaño;
        if (vidaTemporal < 0)
        {
            VidaActual = 0;
        }
        else
        {
            VidaActual = vidaTemporal;
        }

        cambioVida.Invoke(VidaActual);

        if (VidaActual <= 0)
        {
            vidaCero.Invoke(); // Invocar el evento cuando la vida llegue a 0
            if (cronometro != null)
            {
                cronometro.DetenerCronometro();
                lostText.SetActive(true);
            }
            Destroy(gameObject); // Destruir el objeto del jugador
        }
    }

    public void CurarVida(int CantidadDeCuracion)
    {
        int vidaTemporal = VidaActual + CantidadDeCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            VidaActual = vidaMaxima;
        }
        else
        {
            VidaActual = vidaTemporal;
        }

        cambioVida.Invoke(VidaActual);
    }
}
