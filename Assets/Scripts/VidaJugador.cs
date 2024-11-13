using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int VidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    public UnityEvent vidaCero; // Evento que se dispara cuando la vida llega a 0

    public int valorPrueba;

    private void Start()
    {
        VidaActual = vidaMaxima;
        cambioVida.Invoke(VidaActual);
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
