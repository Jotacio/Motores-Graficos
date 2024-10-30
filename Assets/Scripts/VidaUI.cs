using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;  

public class VidaUI : MonoBehaviour
{
    public List<Image> listaCorazones;
    
    public GameObject corazonPrefab;
    
    public VidaJugador vidaJugador;
    
    public int indexActual;
    
    public Sprite corazonLleno;

    public Sprite corazonVacio;

    private void Awake() 
    {
        vidaJugador.cambioVida.AddListener(CambiarCorazones);
    }

    private void CambiarCorazones(int vidaActual)
    {
        if (!listaCorazones.Any())
        {
            CrearCorazones(vidaActual);
        }
        else
        {
            CambiarVida(vidaActual);
        }   
    }
    private void CrearCorazones(int cantidadMaximavida)
    {
        for (int i = 0; i < cantidadMaximavida; i++) 
        {
            GameObject corazon = Instantiate(corazonPrefab,transform);
            listaCorazones.Add(corazon.GetComponent<Image>());
        }
        indexActual = cantidadMaximavida - 1;
    }

    private void CambiarVida(int vidaActual)
    {
        if (vidaActual <= indexActual) 
        {
            QuitarCorazones(vidaActual);
        }
        else 
        {
            AgregarVida(vidaActual);
        }
    }
    private void QuitarCorazones(int vidaActual)
    {
        for (int i = indexActual; i >= vidaActual; i--)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonVacio;
        }
    }
    private void AgregarVida(int vidaActual)
    {
        for (int i = indexActual; i < vidaActual; i++)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonLleno;
        }
    }

   
}

