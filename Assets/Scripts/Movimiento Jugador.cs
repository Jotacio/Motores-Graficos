using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 10; // Velocidad como entero
    public Camera playerCamera;
    private CharacterController characterController;
    public float alturaSalto = 2;
    public int intervaloSalto = 3;
    private bool puedeSaltar = false;
    private float verticalVelocity;
    private float gravity = 9.81f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        StartCoroutine(RutinaIntervaloSalto());
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = playerCamera.transform.TransformDirection(movement); // Mover en dirección de la cámara

        if (characterController.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime; // Mantener al personaje en el suelo

            // Control de salto
            if (puedeSaltar && Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(2 * alturaSalto * gravity);
                puedeSaltar = false;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; // Aplicar gravedad mientras está en el aire
        }

        movement.y = verticalVelocity;
        characterController.Move(movement * Time.deltaTime * speed);

        // Rotar el personaje en dirección de la cámara solo si se está moviendo
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * speed);
        }
    }

    public void IncreaseSpeed(int amount)
    {
        speed += amount;
        Debug.Log("Velocidad aumentada: " + speed);
    }

    public void ReducirVelocidad(int cantidad)
    {
        StartCoroutine(ReducirVelocidadTemporalmente(cantidad, 5f));
    }

    private IEnumerator ReducirVelocidadTemporalmente(int cantidad, float duracion)
    {
        int velocidadOriginal = speed;
        speed -= Mathf.Abs(cantidad); // Asegurarse de que la reducción siempre sea positiva

        if (speed < 0)
        {
            speed = 0; // Asegurarse de que la velocidad no sea negativa
        }

        Debug.Log("Velocidad reducida a: " + speed);

        yield return new WaitForSeconds(duracion);

        speed = velocidadOriginal;
        Debug.Log("Velocidad restaurada a: " + speed);
    }

    private IEnumerator RutinaIntervaloSalto()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervaloSalto);
            puedeSaltar = true;
        }
    }
}


