using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform target; // El jugador
    [SerializeField]
    private float detectionRange = 10f; // Rango máximo de detección
    [SerializeField]
    private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField]
    private Transform firePoint; // Punto desde donde se dispara la bala
    [SerializeField]
    private float fireInterval = 2f; // Intervalo de disparo
    [SerializeField]
    private Transform rotatingPart; // El cubo dentro de la torreta que debe girar
    [SerializeField]
    private float rotationSpeed = 5f; // Velocidad de rotación
    [SerializeField]
    private AudioClip fireSound; // Sonido de disparo
    [SerializeField]
    private float fireSoundVolume = 0.5f; // Volumen del sonido de disparo (0.0 a 1.0)

    private AudioSource audioSource; // Fuente de audio
    private bool targetInRange = false;
    private bool isFiring = false; // Variable para controlar el disparo

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
        audioSource.volume = fireSoundVolume; // Ajustar el volumen
        audioSource.playOnAwake = false; // Asegurarse de que el sonido no se reproduzca al iniciar
    }

    void Update()
    {
        DetectTarget();
    }

    void DetectTarget()
    {
        Vector3 directionToTarget = target.position - rotatingPart.position;
        directionToTarget.y = 0; // Ignorar el componente vertical del movimiento

        if (Vector3.Distance(rotatingPart.position, target.position) <= detectionRange)
        {
            targetInRange = true;

            // Calcular la rotación hacia el objetivo
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Mantener la rotación del cubo en el eje Y
            Vector3 eulerRotation = targetRotation.eulerAngles;
            eulerRotation.x = rotatingPart.eulerAngles.x; // Mantener la rotación actual en X
            eulerRotation.z = rotatingPart.eulerAngles.z; // Mantener la rotación actual en Z

            rotatingPart.rotation = Quaternion.Slerp(rotatingPart.rotation, Quaternion.Euler(eulerRotation), rotationSpeed * Time.deltaTime);

            if (!isFiring) // Comienza a disparar solo si no está ya disparando
            {
                StartCoroutine(FireRoutine());
            }
        }
        else
        {
            targetInRange = false;
        }
    }

    IEnumerator FireRoutine()
    {
        isFiring = true;
        while (targetInRange)
        {
            Fire();
            yield return new WaitForSeconds(fireInterval);
        }
        isFiring = false;
    }

    void Fire()
    {
        // Instanciar la bala y asegurar que su rotación coincida con el firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        audioSource.Play(); // Reproducir el sonido del disparo
        Debug.Log("Disparando al jugador");
    }
}
