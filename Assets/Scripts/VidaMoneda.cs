using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMoneda : MonoBehaviour
{
    public float lifeSpan = 5f; // Tiempo de vida de la moneda en segundos

    void Start()
    {
        Destroy(gameObject, lifeSpan); // Destruir la moneda
    }
}
