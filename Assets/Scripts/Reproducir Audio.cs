using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAudio : MonoBehaviour
{
    public AudioSource fuenteAudio;
    public AudioClip fuenteClip;
    public float volumen = 1;

    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        fuenteAudio.clip = fuenteClip;
        fuenteAudio.volume = volumen;
        fuenteAudio.loop = true; // Para que la música de fondo se repita en bucle
        fuenteAudio.Play(); // Reproducir la música al inicio
    }

    public void StopAudio()
    {
        if (fuenteAudio.isPlaying)
        {
            fuenteAudio.Stop();
        }
    }
}

