using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    private bool escudoActivo = false;
    private Transform playerTransform;
    private GameObject escudoVisual; // Instancia del efecto visual del escudo

    private void Start()
    {
        playerTransform = transform; // Asume que este script está en el objeto del jugador
    }

    public void ActivarEscudo(GameObject escudoVisualPrefab)
    {
        escudoActivo = true;

        // Instanciar el efecto visual del escudo
        escudoVisual = Instantiate(escudoVisualPrefab, playerTransform.position, Quaternion.identity);
        escudoVisual.transform.SetParent(playerTransform); // Hacer que el efecto visual sea hijo del jugador para que se mueva con él

        Debug.Log("Escudo activado");
    }

    public void DesactivarEscudo()
    {
        escudoActivo = false;

        // Destruir el efecto visual del escudo
        if (escudoVisual != null)
        {
            Destroy(escudoVisual);
        }

        Debug.Log("Escudo desactivado");
    }

    public bool EscudoEstaActivo()
    {
        return escudoActivo;
    }

    public bool BloquearDaño()
    {
        if (escudoActivo)
        {
            DesactivarEscudo();
            return true; // Daño bloqueado
        }
        return false; // Daño no bloqueado
    }
}
