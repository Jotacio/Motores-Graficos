using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private bool escudoActivo = false;
    private Transform playerTransform;
    public float orbitaVelocidad = 50f; // Velocidad de orbitaci�n

    private GameObject escudoVisual; // Objeto visual del escudo

    private void Start()
    {
        playerTransform = transform; // Asume que este script est� en el objeto del jugador
    }

    public void ActivarEscudo(GameObject escudoPrefab)
    {
        escudoActivo = true;
        escudoVisual = Instantiate(escudoPrefab, playerTransform.position, Quaternion.identity);
        escudoVisual.transform.SetParent(playerTransform); // Hacer que el escudo sea hijo del jugador para facilitar la orbitaci�n
        Debug.Log("Escudo activado");
    }

    public void DesactivarEscudo()
    {
        escudoActivo = false;
        if (escudoVisual != null)
        {
            Destroy(escudoVisual);
        }
        Debug.Log("Escudo desactivado");
    }

    private void Update()
    {
        if (escudoActivo && escudoVisual != null)
        {
            escudoVisual.transform.RotateAround(playerTransform.position, Vector3.up, orbitaVelocidad * Time.deltaTime);
        }
    }

    public bool EscudoEstaActivo()
    {
        return escudoActivo;
    }

    public bool BloquearDa�o()
    {
        if (escudoActivo)
        {
            DesactivarEscudo();
            return true; // Da�o bloqueado
        }
        return false; // Da�o no bloqueado
    }
}
