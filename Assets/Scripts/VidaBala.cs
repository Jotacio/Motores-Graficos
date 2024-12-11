using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaBala : MonoBehaviour
{
    [SerializeField]
    private int _speed = 2;
    [SerializeField]
    private int _time = 5;
    public int daño;
    void Start()
    {
        Destroy(gameObject, _time);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomarDaño(daño);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<VidaJugador>() != null)
        {
            collision.gameObject.GetComponent<VidaJugador>().TomarDaño(daño);
        }
        else if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }

}
