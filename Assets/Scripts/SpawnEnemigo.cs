using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // Lista de prefabs de enemigos
    public float spawnInterval = 3f; // Intervalo de tiempo entre spawns
    private float timer = 0f;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomPositionWithinBox();

        // Seleccionar un prefab aleatorio de la lista
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionWithinBox()
    {
        Vector3 boxSize = boxCollider.size;
        Vector3 boxCenter = boxCollider.center;
        float x = Random.Range(-boxSize.x / 2, boxSize.x / 2);
        float y = Random.Range(-boxSize.y / 2, boxSize.y / 2);
        float z = Random.Range(-boxSize.z / 2, boxSize.z / 2);
        Vector3 randomPosition = boxCenter + new Vector3(x, y, z);
        return transform.TransformPoint(randomPosition); // Convertir a coordenadas globales
    }
}
