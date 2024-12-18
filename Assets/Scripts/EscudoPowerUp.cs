using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EscudoPowerUp : MonoBehaviour
{
    public float duracionEscudo = 2f; // Duración del escudo en segundos
    public GameObject escudoVisualPrefab; // Prefab del efecto visual del escudo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Escudo escudo = other.GetComponent<Escudo>();
            if (escudo != null)
            {
                escudo.ActivarEscudo(escudoVisualPrefab);
                StartCoroutine(DesactivarEscudoDespuesDeTiempo(escudo));
                Destroy(gameObject); // Destruir el power-up después de recogerlo
            }
        }
    }

    private IEnumerator DesactivarEscudoDespuesDeTiempo(Escudo escudo)
    {
        yield return new WaitForSeconds(duracionEscudo);
        escudo.DesactivarEscudo();
    }
}
