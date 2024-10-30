using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDaño : MonoBehaviour
{
    public int daño;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.Tomardaño(daño);
        }
    }
}
