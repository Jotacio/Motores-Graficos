using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnfantasma : MonoBehaviour
{
    public GameObject spawnFantasma;
    public int intervaloSpawn = 15;
    private float timer = 0f;
    private GameObject currentFantasma;

    private void Start()
    {
        spawnFantasma.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= intervaloSpawn)
        {
            spawnFantasma.SetActive(true);
            if (currentFantasma == null)
            {
                fantasmaSpawn();
                timer = 0f;
                Destroy(gameObject);
            }
        }
    }

    private void fantasmaSpawn()
    { 

        currentFantasma = Instantiate(spawnFantasma,transform.position,transform.rotation);
    }
}
