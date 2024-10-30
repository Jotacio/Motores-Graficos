using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuntarMoneda : MonoBehaviour
{
        public string playerTag = "Player"; // Etiqueta del jugador
        public int speedIncrease = 5; // Incremento de velocidad

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    playerController.IncreaseSpeed(speedIncrease);
                }

                // Destruir la moneda después de recogerla
                Destroy(gameObject);
            }

        }
   
}
