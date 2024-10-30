using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class VidaJugador : MonoBehaviour
{
    public int VidaActual;

    public int vidaMaxima;
    private GameObject GameObject;

    public UnityEvent<int> cambioVida;

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
            Tomardaño(valorPrueba);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            CurarVida(valorPrueba);
        }
    }
    public void Tomardaño(int cantidadDaño)
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
            Destroy(GameObject);
        }
    }
    public void CurarVida(int CantidadDeCuracion)
    {
        int vidaTemporal = VidaActual + CantidadDeCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            vidaTemporal = vidaMaxima;
        }
        else
        {
            vidaTemporal = VidaActual;
        }

        cambioVida.Invoke(VidaActual);
    }
}
