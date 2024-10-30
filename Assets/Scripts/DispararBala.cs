using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBala : MonoBehaviour
{
    [SerializeField]
    private GameObject _bala;
    [SerializeField]
    private float _timer = 2f;
    private int _counter;
    [SerializeField]
    private int _maxCounter = 20;

    void Start()
    {
        StartCoroutine(FireBullets_CR());
    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coroutine");
        for (_counter = 0; _counter < _maxCounter; _counter++)
        {
            Instantiate(_bala, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer); // Esperar antes de disparar la siguiente bala
        }
        Debug.Log("Fin coroutine");
    }
}
