using System.Collections;
using System.Collections.Generic;
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
            vidaJugador.Tomardaño(daño);
        }
    }
}
