using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitarObjeto : MonoBehaviour
{
    public string playerTag = "Player"; // Etiqueta del jugador
    public int speedDecrease = 5; // Reducci�n de velocidad (valor positivo)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ReducirVelocidad(speedDecrease);
            }
            // Destruir el objeto despu�s de que el jugador lo toque
            Destroy(gameObject);
        }
    }
}