using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 10; // Velocidad como entero
    public Camera playerCamera;
    private CharacterController characterController;
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = playerCamera.transform.TransformDirection(movement); // Mover en dirección de la cámara
        movement.y = 0f; // Asegurarse de que no haya movimiento en el eje Y
        characterController.Move(movement * speed * Time.deltaTime);

        // Rotar el personaje en dirección de la cámara
        if (movement != Vector3.zero)
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
}

