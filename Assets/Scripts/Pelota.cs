using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public AudioClip sonido;
    public GameObject siguientePelota;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonido;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.minDistance = 1.0f;
        audioSource.maxDistance = 25.0f;

        // Asegurarse de que la pelota está inicialmente inactiva, excepto la primera
        if (siguientePelota != null)
        {
            siguientePelota.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Detener el sonido inmediatamente
            audioSource.Stop();

            // Activar la siguiente pelota
            if (siguientePelota != null)
            {
                siguientePelota.SetActive(true);
            }

            // Destruir la pelota para evitar múltiples activaciones
            Destroy(gameObject);
        }
    }
}
