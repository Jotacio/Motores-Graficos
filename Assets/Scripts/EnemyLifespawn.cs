using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSpan : MonoBehaviour
{
    public float lifeSpan = 5f; // Tiempo de vida del enemigo en segundos

    void Start()
    {
        Destroy(gameObject, lifeSpan); // Destruir el enemigo despu�s de 'lifeSpan' segundos
    }
    
}

