using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaAI : MonoBehaviour
{
    public float speed = 5f; // Velocidad del fantasma
    private Transform player;
    private VidaJugador vidaJugador;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            vidaJugador = player.GetComponent<VidaJugador>();
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Perseguir al jugador
            Vector3 direction = (player.position - transform.position).normalized;
            float distance = Vector3.Distance(player.position, transform.position);

            if (distance > 1f)
            {
                Vector3 movePosition = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                transform.position = movePosition;
                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z)); // Hacer que el fantasma mire al jugador
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && vidaJugador != null)
        {
            vidaJugador.TomarDaño(vidaJugador.VidaActual); // Eliminar todas las vidas del jugador
            Destroy(gameObject); // Destruir el fantasma
        }
    }
}
