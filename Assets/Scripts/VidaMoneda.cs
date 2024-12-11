using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMoneda : MonoBehaviour
{
    public float lifeSpan = 5f; // Tiempo de vida de la moneda en segundos
    public float rotationSpeed = 90f; // Velocidad de rotación en grados por segundo
    public AudioClip sonidoMoneda; // Sonido de la moneda
    public float volumenSonido = 1.0f;

    private AudioSource audioSource; // Fuente de audio

    void Start()
    {
        // Configurar la destrucción de la moneda después del tiempo de vida
        Destroy(gameObject, lifeSpan);

        // Agregar y configurar el componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sonidoMoneda;
        audioSource.playOnAwake = false; // No reproducir el sonido automáticamente
        audioSource.volume = volumenSonido;
    }

    void Update()
    {
        // Rotar la moneda sobre su propio eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproducir el sonido de la moneda
            audioSource.Play();

            // Destruir la moneda después de que se haya reproducido el sonido
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
