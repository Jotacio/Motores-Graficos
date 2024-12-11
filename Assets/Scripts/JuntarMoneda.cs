using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarMoneda : MonoBehaviour
{
    public string playerTag = "Player"; // Etiqueta del jugador
    public int speedIncrease = 5; // Incremento de velocidad

    private AudioSource audioSource; // Fuente de audio

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.IncreaseSpeed(speedIncrease);
            }

            // Reproducir el sonido de la moneda
            audioSource.Play();

            // Destruir la moneda después de un pequeño retraso para que el sonido se reproduzca
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
