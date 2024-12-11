using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public string targetTag = "Target"; // Etiqueta del personaje que se toca para ganar
    public GameObject winText; // Referencia al texto de la UI que se mostrará
    public CronometroTMP cronometroScript;
    

    private void Start()
    {
        winText.SetActive(false); // Asegurarse de que el texto está desactivado al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            winText.SetActive(true); // Mostrar el texto de victoria
            if (cronometroScript != null)
            {
                // Detener el cronómetro
                cronometroScript.DetenerCronometro();
                Debug.Log("¡Victoria! Cronómetro detenido.");
                                
                // Destruir el objeto de victoria después de que el jugador lo toque
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("CronometroScript no está asignado en el Inspector.");
            }
        }
    }
}

